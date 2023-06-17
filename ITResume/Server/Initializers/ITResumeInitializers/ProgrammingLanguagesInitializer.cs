using ITResume.Server.Settings;
using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using Newtonsoft.Json;
using System.Globalization;

namespace ITResume.Server.Initializers.ITResumeInitializers;

public class ProgrammingLanguagesInitializer
{
    public static async Task<IEnumerable<ProgrammingLanguage>> GetAllProgrammingLanguagesAsync()
    {
        Uri url = new Uri("https://api.github.com/languages");
        HttpClient httpClient = new HttpClient() { BaseAddress = url };

        httpClient.DefaultRequestHeaders.Add("User-Agent", "C# HttpClient");
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Token {GithubSettings.Token}");

        var roots = (await httpClient.GetFromJsonAsync<List<Root>>(string.Empty))!;
        IEnumerable<ProgrammingLanguage> programmingLanguage = roots.Select(r => new ProgrammingLanguage() { Name = r.Name });
        return programmingLanguage;
    }
}

public class Root
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("aliases")]
    public List<string> Aliases { get; set; } = null!;
}
