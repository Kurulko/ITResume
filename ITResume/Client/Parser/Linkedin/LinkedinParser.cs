using ITResume.Client.Parser.Linkedin.Models;
using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;
using Newtonsoft.Json;
using Octokit;
using Project = ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels.Project;

namespace ITResume.Client.Parser.Linkedin;

public class LinkedinParser : ISiteParser
{
    readonly string linkedinUserid;
    public LinkedinParser(string linkedinUserid)
        => this.linkedinUserid = linkedinUserid;

    public Contact Contact { get; set; } = null!;
    public IEnumerable<Employee> Employees { get; set; } = null!;
    public IEnumerable<Education> Educations { get; set; } = null!;
    public IEnumerable<Project> Projects { get; set; } = null!;
    public IEnumerable<ForeignLanguage> ForeignLanguages { get; set; } = null!;
    public IEnumerable<Technology> Technologies { get; set; } = null!;

    public async Task ParseAsync()
    {
        string accessToken = string.Empty;//TO-DO

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            string url = $"https://api.linkedin.com/v2/{linkedinUserid}";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                UserProfile? profile = JsonConvert.DeserializeObject<UserProfile>(json);

                if (profile is not null)
                {
                    var ci = profile.ContactInfo;
                    if (ci is not null)
                        Contact = new() { Email = ci.EmailAddress, MobilePhone = ci.PhoneNumbers?.FirstOrDefault()?.Number };

                    var ues = profile.Educations;
                    if (ues is not null)
                        Educations = ues.Select(ue => new Education() { University = ue.SchoolName!, StartEducation = new(ue.StartDate?.Year ?? DateTime.Now.Year, 0, 0), FinishEducation = new(ue.EndDate?.Year ?? DateTime.Now.Year, 0, 0) });

                    var uls = profile.Languages;
                    if (uls is not null)
                        ForeignLanguages = uls.Select(ul => new ForeignLanguage() { HumanLanguage = new() { Name = ul.Language!.Name! } });

                    var ups = profile.Projects;
                    if (ups is not null)
                        Projects = ups.Select(up => new Project() {  Name = up.Title!, Description = up.Description });

                    var uss = profile.Skills;
                    if (uss is not null)
                        Technologies = uss.Select(us => new Technology() { Name = us.Name! });

                    return;
                }
            }

            throw new Exception("Something went wrong...");
        }
    }
}








