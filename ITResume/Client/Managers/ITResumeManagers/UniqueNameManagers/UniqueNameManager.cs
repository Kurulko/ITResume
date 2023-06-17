using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Services.ITResumeServices.UniqueNameServices;
using System.Web;

namespace ITResume.Client.Managers.ITResumeManagers.UniqueNameManagers;

public abstract class UniqueNameManager<T> : ITResumeDbModelManager<T>, IUniqueNameService<T> where T : UniqueNameModel, new()
{
    protected UniqueNameManager(HttpClient httpClient, string url) : base(httpClient, url) { }

    public virtual async Task<T?> GetModelByUniqueNameAsync(string uniqueName)
        => await CheckModel<T>($"name/{HttpUtility.UrlEncode(uniqueName)}");
}
