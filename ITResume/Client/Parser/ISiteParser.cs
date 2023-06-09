using ITResume.Shared.Models.Database;
using Octokit;

namespace ITResume.Client.Parser;

public interface ISiteParser
{
    Task ParseAsync();
}
