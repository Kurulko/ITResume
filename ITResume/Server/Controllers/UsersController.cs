using ITResume.Shared.Models.Account;
using ITResume.Shared;
using ITResume.Shared.Models.ViewModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Octokit;
using User = ITResume.Shared.Models.Database.User;
using Project = ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels.Project;
using System.Security.Claims;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;
using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;

namespace ITResume.Server.Controllers;

public class UsersController : AdminDbModelsController<User, string>
{
    public UsersController(IUserService service) : base(service) { }

    IUserService userService => (service as IUserService)!;

    [AllowAnonymous]
    [HttpGet("userid-by-name/{userName}")]
    public async Task<string?> GetUserIdByUserNameAsync(string userName)
        => await userService.GetUserIdByUserNameAsync(userName);

    [AllowAnonymous]
    [HttpGet("is-public-profile/{userName}")]
    public async Task<bool> IsPublicProfile(string userName)
        => await userService.IsPublicProfile(userName);

    [AllowAnonymous]
    [HttpGet("public-profiles")]
    public async Task<IEnumerable<User>> GetPublicProfilesAsync()
        => await userService.GetPublicProfilesAsync();


    [AllowAnonymous]
    [HttpGet("current-username")]
    public async Task<string?> GetCurrentUserNameAsync()
    {
        CheckAccess();
        return await userService.GetCurrentUserNameAsync();
    }

    [AllowAnonymous]
    [HttpGet("{userId}/is-impersonating")]
    public async Task<bool> IsImpersonating(string userId)
    {
        CheckAccessForUser(userId);
        return await userService.IsImpersonating(userId);
    }

    [AllowAnonymous]
    public override async Task<User?> GetModelByIdAsync(string key)
    {
        CheckAccessForUser(key);
        return await base.GetModelByIdAsync(key);
    }

    [AllowAnonymous]
    [HttpGet("current")]
    public virtual async Task<User?> GetUserByClaimsAsync()
    {
        CheckAccess();
        return await userService.GetUserByClaimsAsync(User);
    }

    [AllowAnonymous]
    public override async Task<IActionResult> UpdateModelAsync(User model)
    {
        CheckAccessForUser(model.Id);
        return await base.UpdateModelAsync(model);
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


    const string userContact = "user-contact" ,userAchievements = "user-achievements" ,userEducations = "user-educations"
    ,userEmployees = "user-employees" ,userProgrammingLanguages = "user-programming-languages", userForeignLanguages = "user-foreign-languages"
    ,userProjects = "user-projects" ,userTechnologies = "user-technologies";

    [AllowAnonymous]
    [HttpGet(userContact)]
    public virtual async Task<Contact?> GetCurrentUserContactAsync()
    {
        CheckAccess();
        return await userService.GetCurrentUserContactAsync();
    }

    [AllowAnonymous]
    [HttpGet(userAchievements)]
    public virtual async Task<IEnumerable<Achievement>> GetCurrentUserAchievementsAsync()
    {
        CheckAccess();
        return await userService.GetCurrentUserAchievementsAsync();
    }


    [AllowAnonymous]
    [HttpGet(userEducations)]
    public virtual async Task<IEnumerable<Education>> GetCurrentUserEducationsAsync()
    {
        CheckAccess();
        return await userService.GetCurrentUserEducationsAsync();
    }

    [AllowAnonymous]
    [HttpGet(userEmployees)]
    public virtual async Task<IEnumerable<Employee>> GetCurrentUserEmployeesAsync()
    {
        CheckAccess();
        return await userService.GetCurrentUserEmployeesAsync();
    }

    [AllowAnonymous]
    [HttpGet(userForeignLanguages)]
    public virtual async Task<IEnumerable<ForeignLanguage>> GetCurrentUserForeignLanguagesAsync()
    {
        CheckAccess();
        return await userService.GetCurrentUserForeignLanguagesAsync();
    }

    [AllowAnonymous]
    [HttpGet(userProgrammingLanguages)]
    public virtual async Task<IEnumerable<ProgrammingLanguage>> GetCurrentUserProgrammingLanguagesAsync()
    {
        CheckAccess();
        return await userService.GetCurrentUserProgrammingLanguagesAsync();
    }

    [AllowAnonymous]
    [HttpGet(userProjects)]
    public virtual async Task<IEnumerable<Project>> GetCurrentUserProjectsAsync()
    {
        CheckAccess();
        return await userService.GetCurrentUserProjectsAsync();
    }




    [AllowAnonymous]
    [HttpGet(userContact + "/{userId}")]
    public virtual async Task<Contact?> GetUserContactAsync(string userId)
        => await userService.GetUserContactAsync(userId);

    [AllowAnonymous]
    [HttpGet(userAchievements + "/{userId}")]
    public virtual async Task<IEnumerable<Achievement>> GetUserAchievementsAsync(string userId)
        => await userService.GetUserAchievementsAsync(userId);


    [AllowAnonymous]
    [HttpGet(userEducations + "/{userId}")]
    public virtual async Task<IEnumerable<Education>> GetUserEducationsAsync(string userId)
        => await userService.GetUserEducationsAsync(userId);

    [AllowAnonymous]
    [HttpGet(userEmployees + "/{userId}")]
    public virtual async Task<IEnumerable<Employee>> GetUserEmployeesAsync(string userId)
        => await userService.GetUserEmployeesAsync(userId);

    [AllowAnonymous]
    [HttpGet(userForeignLanguages + "/{userId}")]
    public virtual async Task<IEnumerable<ForeignLanguage>> GetUserForeignLanguagesAsync(string userId)
        => await userService.GetUserForeignLanguagesAsync(userId);

    [AllowAnonymous]
    [HttpGet(userProgrammingLanguages + "/{userId}")]
    public virtual async Task<IEnumerable<ProgrammingLanguage>> GetUserProgrammingLanguagesAsync(string userId)
        => await userService.GetUserProgrammingLanguagesAsync(userId);

    [AllowAnonymous]
    [HttpGet(userProjects + "/{userId}")]
    public virtual async Task<IEnumerable<Project>> GetUserProjectsAsync(string userId)
        => await userService.GetUserProjectsAsync(userId);

    [AllowAnonymous]
    [HttpGet(userTechnologies + "/{userId}")]
    public virtual async Task<IEnumerable<Technology>> GetUserTechnologiesAsync(string userId)
        => await userService.GetUserTechnologiesAsync(userId);


    [AllowAnonymous]
    [HttpGet("{userId}/password")]
    public async Task<bool> HasPassword(string userId)
    {
        CheckAccessForUser(userId);
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
    public async Task<IActionResult> CreatePassword(ModelWithUserId<string> model)
        => await ReturnOkIfEverithingIsGood(async () => await userService.AddUserPasswordAsync(model));

    [AllowAnonymous]
    [HttpGet("{userId}/roles")]
    public async Task<IEnumerable<string>> GetRoles(string userId)
    {
        CheckAccessForUser(userId);
        return await userService.GetRolesAsync(userId);
    }

    [HttpPost("{userId}/role")]
    public async Task<IActionResult> AddRole(string userId, [FromBody] string roleName)
        => await ReturnOkIfEverithingIsGood(async () => await userService.AddRoleToUserAsync(new(userId, roleName)));

    [HttpDelete("{userId}/{roleName}")]
    public async Task<IActionResult> DeleteRole(string userId, string roleName)
        => await ReturnOkIfEverithingIsGood(async () => await userService.DeleteRoleFromUserAsync(new(userId, roleName)));

    void CheckAccessForUser(string userId)
    {
        if (!(User.IsInRole(Roles.Admin) || User.FindFirstValue(ClaimTypes.NameIdentifier) == userId))
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
