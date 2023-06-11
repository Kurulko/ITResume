using ITResume.Shared.Models.Account;
using ITResume.Shared;
using ITResume.Shared.Models.Database;
using ITResume.Shared.Models.ViewModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Octokit;
using User = ITResume.Shared.Models.Database.User;
using Project = ITResume.Shared.Models.Database.Project;

namespace ITResume.Server.Controllers;

public class UsersController : AdminDbModelsController<User, string>
{
    public UsersController(IUserService service) : base(service) { }

    IUserService userService => (service as IUserService)!;

    [AllowAnonymous]
    public override async Task<User?> GetModelByIdAsync(string key)
    {
        await CheckAccessForUser(key);
        return await base.GetModelByIdAsync(key);
    }

    [AllowAnonymous]
    [HttpGet("current")]
    public virtual async Task<User?> GetUserByClaimsAsync()
    {
        CheckAccess();
        return await userService.GetUserByClaimsAsync(User);
    }


    [HttpGet("name")]
    public virtual async Task<User?> GetUserByNameAsync(string name)
        => await userService.GetUserByNameAsync(name);

    [HttpGet("usedUser")]
    public virtual async Task<User> GetUsedUserAsync()
        => await userService.GetUsedUserAsync();

    [HttpPut("change-usedUserId")]
    public async Task ChangeUsedUserIdAsync(UserAndUsedUser args)
        => await ReturnOkIfEverithingIsGood(async () => await userService.ChangeUsedUserIdAsync(args.UserId, args.UsedUserId!));

    [HttpPut("drop-usedUserId")]
    public async Task DropUsedUserIdAsync(UserAndUsedUser args)
        => await ReturnOkIfEverithingIsGood(async () => await userService.DropUsedUserIdAsync(args.UserId));

    [AllowAnonymous]
    [HttpGet("user-contact")]
    public virtual async Task<Contact?> GetUserContactAsync()
    {
        CheckAccess();
        return await userService.GetUserContactAsync();
    }

    [AllowAnonymous]
    [HttpGet("user-achievements")]
    public virtual async Task<IEnumerable<Achievement>> GetUserAchievementsAsync()
    {
        CheckAccess();
        return await userService.GetUserAchievementsAsync();
    }


    [AllowAnonymous]
    [HttpGet("user-educations")]
    public virtual async Task<IEnumerable<Education>> GetUserEducationsAsync()
    {
        CheckAccess();
        return await userService.GetUserEducationsAsync();
    }

    [AllowAnonymous]
    [HttpGet("user-employees")]
    public virtual async Task<IEnumerable<Employee>> GetUserEmployeesAsync()
    {
        CheckAccess();
        return await userService.GetUserEmployeesAsync();
    }

    [AllowAnonymous]
    [HttpGet("user-foreign-languages")]
    public virtual async Task<IEnumerable<ForeignLanguage>> GetUserForeignLanguagesAsync()
    {
        CheckAccess();
        return await userService.GetUserForeignLanguagesAsync();
    }

    [AllowAnonymous]
    [HttpGet("user-programming-languages")]
    public virtual async Task<IEnumerable<ProgrammingLanguage>> GetUserProgrammingLanguagesAsync()
    {
        CheckAccess();
        return await userService.GetUserProgrammingLanguagesAsync();
    }

    [AllowAnonymous]
    [HttpGet("user-projects")]
    public virtual async Task<IEnumerable<Project>> GetUserProjectsAsync()
    {
        CheckAccess();
        return await userService.GetUserProjectsAsync();
    }

    [AllowAnonymous]
    [HttpGet("user-technologies")]
    public virtual async Task<IEnumerable<Technology>> GetUserTechnologiesAsync()
    {
        CheckAccess();
        return await userService.GetUserTechnologiesAsync();
    }

    [AllowAnonymous]
    [HttpGet("{userId}/password")]
    public async Task<bool> HasPassword(string userId)
    {
        await CheckAccessForUser(userId);
        return await userService.HasUserPasswordAsync(userId);
    }

    [AllowAnonymous]
    [HttpPut("password")]
    public async Task<IActionResult> ChangePassword(ChangePassword model)
    => await ReturnOkIfEverithingIsGood(async () =>
    {
        CheckAccess();
        await userService.ChangeUserPasswordAsync(model);
    });

    [HttpPost("password")]
    public async Task<IActionResult> CreatePassword(ModelWithUserId<ChangePassword> model)
        => await ReturnOkIfEverithingIsGood(async () => await userService.AddUserPasswordAsync(model));

    [AllowAnonymous]
    [HttpGet("{userId}/roles")]
    public async Task<IEnumerable<string>> GetRoles(string userId)
    {
        await CheckAccessForUser(userId);
        return await userService.GetRolesAsync(userId);
    }

    [HttpPost("{userId}/role")]
    public async Task<IActionResult> AddRole(string userId, [FromBody] string roleName)
        => await ReturnOkIfEverithingIsGood(async () => await userService.AddRoleToUserAsync(new(userId, roleName)));

    [HttpDelete("{userId}/{roleName}")]
    public async Task<IActionResult> DeleteRole(string userId, string roleName)
        => await ReturnOkIfEverithingIsGood(async () => await userService.DeleteRoleFromUserAsync(userId, roleName));

    async Task CheckAccessForUser(string userId)
    {
        User? currentUser = await GetUserByClaimsAsync();
        if (!(currentUser is User _user && (User.IsInRole(Roles.Admin) || _user.Id == userId)))
            AccessDenied();
    }

    void CheckAccess()
    {
        if (!User.Identity?.IsAuthenticated ?? false)
            AccessDenied();
    }

    void AccessDenied()
        => throw new UnauthorizedAccessException("Access to this source is denied!");
}
