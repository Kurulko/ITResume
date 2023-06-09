using ITResume.Client.Managers.AccountManagers;
using ITResume.Shared.Models.Account;
using ITResume.Shared.Services.Account;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ITResume.Client.Managers;

public class CustomStateProvider : AuthenticationStateProvider
{
    CurrentUser? currentUser;

    readonly IAuthService auth;
    public CustomStateProvider(IAuthService auth)
        => this.auth = auth;

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsIdentity identity = new();
        try
        {
            CurrentUser user = await GetCurrentUser();
            if (user.IsAuthenticated)
            {
                var claims = new[] { new Claim(ClaimTypes.Name, currentUser!.UserName) }.Concat(currentUser.Claims.Select(c => new Claim(c.Key, c.Value)));
                identity = new ClaimsIdentity(claims, "Server authentication");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("Request failed:" + ex.ToString());
        }
        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    async Task<CurrentUser> GetCurrentUser()
    {
        if (currentUser is not null && currentUser.IsAuthenticated)
            return currentUser;
        currentUser = await (auth as AuthManager)!.CurrentUserInfo();
        return currentUser;
    }

    public async Task Login(LoginModel model)
    {
        await auth.LoginUserAsync(model);
        Notify();
    }

    public async Task Register(RegisterModel model)
    {
        await auth.RegisterUserAsync(model);
        Notify();
    }

    public async Task Logout()
    {
        await auth.LogoutUserAsync();
        currentUser = null;
        Notify();
    }

    void Notify()
        => NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
}
