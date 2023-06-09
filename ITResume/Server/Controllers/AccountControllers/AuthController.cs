using ITResume.Shared.Models.Account;
using ITResume.Shared.Services.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.AccountControllers;

[AllowAnonymous]
public class AuthController : ApiController
{
    readonly IAuthService accManager;
    public AuthController(IAuthService accManager)
        => this.accManager = accManager;

    [AllowAnonymous]
    [HttpPost(nameof(Register))]
    public async Task<IActionResult> Register(RegisterModel register)
        => await ReturnOkIfEverithingIsGood(async () => await accManager.RegisterUserAsync(register));


    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login(LoginModel login)
        => await ReturnOkIfEverithingIsGood(async () => await accManager.LoginUserAsync(login));


    [Authorize]
    [HttpPost(nameof(Logout))]
    public async Task<IActionResult> Logout()
        => await ReturnOkIfEverithingIsGood(async () => await accManager.LogoutUserAsync());


    [HttpGet(nameof(CurrentUserInfo))]
    public Task<CurrentUser> CurrentUserInfo()
    {
        var identity = User.Identity;
        var currentUser = new CurrentUser
        {
            IsAuthenticated = identity?.IsAuthenticated ?? false,
            UserName = identity?.Name ?? string.Empty,
            Claims = User.Claims.Select(c => new KeyValuePair<string, string>(c.Type, c.Value)).ToList()
        };
        return Task.FromResult(currentUser);
    }
}
