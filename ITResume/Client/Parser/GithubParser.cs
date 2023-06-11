using ITResume.Shared.Models.Database;
using Octokit;
using Project = ITResume.Shared.Models.Database.Project;

namespace ITResume.Client.Parser;

public class GithubParser : ISiteParser
{
    readonly string githubUsername;
    public GithubParser(string githubUsername)
        => this.githubUsername = githubUsername;

    public IEnumerable<Project> Projects { get; set; } = null!;

    public async Task ParseAsync()
    {
        GitHubClient client = new(new ProductHeaderValue(nameof(ITResume)));
        var repositories = await client.Repository.GetAllForUser(githubUsername);
        Projects = repositories.Select(r =>
            new Project()
            {
                Name = r.Name,
                Description = r.Description,
                Github = r.HtmlUrl,
                StartDoing = r.CreatedAt.UtcDateTime,
                FinishDoing = r.PushedAt?.UtcDateTime,
                ProgrammingLanguages = new List<ProgrammingLanguage>() { new() { Name = r.Language } }
            });
    }
}
