using ITResume.Shared.Models.Database;

namespace ITResume.Client.Managers.ITResumeManagers;

public abstract class ITResumeDbModelManager<T> : DbModelManager<T, long> where T : ITResumeDbModel, new()
{
    protected ITResumeDbModelManager(HttpClient httpClient, string url) : base(httpClient, url) { }
}
