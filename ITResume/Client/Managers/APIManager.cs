using ITResume.Shared.Models.Database;
using System.Net;
using System.Net.Http.Json;

namespace ITResume.Client.Managers;

public class APIManager
{
    protected readonly string url;
    protected readonly HttpClient httpClient;
    public APIManager(HttpClient httpClient, string url)
        => (this.httpClient, this.url) = (httpClient, $"api/{url}");

    protected async Task CheckResponseMessage(HttpResponseMessage message)
    {
        if (message.StatusCode == HttpStatusCode.BadRequest)
            throw new Exception(await message.Content.ReadAsStringAsync());
        message.EnsureSuccessStatusCode();
    }

    protected async Task<T?> CheckModel<T>(string path) where T : new()
    {
        var response = await httpClient.GetAsync($"{url}/{path}");
        if (response.IsSuccessStatusCode)
            return response.StatusCode == HttpStatusCode.NoContent ? new() : await response.Content.ReadFromJsonAsync<T>();
        else
            throw new Exception(await response.Content.ReadAsStringAsync());
    }
}
