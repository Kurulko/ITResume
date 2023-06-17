using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace ITResume.Client.Managers;

public abstract class DbModelManager<T, K> : APIManager, IDbModelService<T, K> where T : IDbModel, new()
{
    public DbModelManager(HttpClient httpClient, string url) : base(httpClient, url) { }

    public async Task<IEnumerable<T>> GetAllModelsAsync()
        => (await httpClient.GetFromJsonAsync<IEnumerable<T>>(url))!;

    public virtual async Task<T?> GetModelByIdAsync(K key)
        => await CheckModel<T>(key!.ToString()!);

    public virtual async Task UpdateModelAsync(T model)
        => await CheckResponseMessage(await httpClient.PutAsJsonAsync(url, model));

    public virtual async Task<T> AddModelAsync(T model)
    {
        var response = await httpClient.PostAsJsonAsync(url, model);
        await CheckResponseMessage(response);
        return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())!;
    }

    public virtual async Task DeleteModelAsync(K key)
        => await CheckResponseMessage(await httpClient.DeleteAsync($"{url}/{key}"));
}
