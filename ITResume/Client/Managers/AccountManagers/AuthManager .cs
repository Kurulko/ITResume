using ITResume.Shared.Models.Account;
using ITResume.Shared.Services.Account;
using System.Net.Http;
using System.Net.Http.Json;

namespace ITResume.Client.Managers.AccountManagers;

public class AuthManager : APIManager, IAuthService
{
    public AuthManager(HttpClient httpClient) : base(httpClient, "auth") { }


    public async Task<CurrentUser> CurrentUserInfo()
        => (await httpClient.GetFromJsonAsync<CurrentUser>($"{url}/CurrentUserInfo"))!;

    public async Task LoginUserAsync(LoginModel model)
        => await CheckResponseMessage(await httpClient.PostAsJsonAsync($"{url}/login", model));

    public async Task RegisterUserAsync(RegisterModel model)
        => await CheckResponseMessage(await httpClient.PostAsJsonAsync($"{url}/register", model));

    public async Task LogoutUserAsync()
        => await CheckResponseMessage(await httpClient.PostAsync($"{url}/logout", null));
}