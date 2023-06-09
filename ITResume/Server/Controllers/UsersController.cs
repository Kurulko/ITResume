using ITResume.Shared.Models.Account;
using ITResume.Shared;
using ITResume.Shared.Models.Database;
using ITResume.Shared.Models.ViewModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers;

//[Authorize(Roles = Roles.Admin)]
public class UsersController : DbModelsController<User, string>
{
    public UsersController(IUserService service) : base(service) { }

    IUserService userService => (service as IUserService)!;

    [Authorize]
    [HttpGet("current")]
    public virtual async Task<User?> GetUserByClaimsAsync()
        => await userService.GetUserByClaimsAsync(User);

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

    [Authorize]
    [HttpGet("user-contact")]
    public virtual async Task<Contact?> GetUserContactAsync()
        => await userService.GetUserContactAsync();

    [Authorize]
    [HttpGet("user-achievements")]
    public virtual async Task<IEnumerable<Achievement>> GetUserAchievementsAsync()
        => await userService.GetUserAchievementsAsync();

    [Authorize]
    [HttpGet("user-educations")]
    public virtual async Task<IEnumerable<Education>> GetUserEducationsAsync()
        => await userService.GetUserEducationsAsync();

    [Authorize]
    [HttpGet("user-employees")]
    public virtual async Task<IEnumerable<Employee>> GetUserEmployeesAsync()
        => await userService.GetUserEmployeesAsync();
    
    [Authorize]
    [HttpGet("user-foreign-languages")]
    public virtual async Task<IEnumerable<ForeignLanguage>> GetUserForeignLanguagesAsync()
        => await userService.GetUserForeignLanguagesAsync();

    [Authorize]
    [HttpGet("user-programming-languages")]
    public virtual async Task<IEnumerable<ProgrammingLanguage>> GetUserProgrammingLanguagesAsync()
        => await userService.GetUserProgrammingLanguagesAsync();

    [Authorize]
    [HttpGet("user-projects")]
    public virtual async Task<IEnumerable<Project>> GetUserProjectsAsync()
        => await userService.GetUserProjectsAsync();

    [Authorize]
    [HttpGet("user-technologies")]
    public virtual async Task<IEnumerable<Technology>> GetUserTechnologiesAsync()
        => await userService.GetUserTechnologiesAsync();

    [Authorize]
    [HttpGet("{userId}/password")]
    public async Task<bool> HasPassword(string userId)
       => await userService.HasUserPasswordAsync(userId);

    [Authorize]
    [HttpPut("password")]
    public async Task<IActionResult> ChangePassword(ChangePassword model)
       => await ReturnOkIfEverithingIsGood(async () => await userService.ChangeUserPasswordAsync(model));

    [HttpPost("password")]
    public async Task<IActionResult> CreatePassword(ModelWithUserId<ChangePassword> model)
        => await ReturnOkIfEverithingIsGood(async () => await userService.AddUserPasswordAsync(model));


    [HttpGet("{userId}/roles")]
    public async Task<IEnumerable<string>> GetRoles(string userId)
        => await userService.GetRolesAsync(userId);

    [HttpPost("{userId}/role")]
    public async Task<IActionResult> AddRole(string userId, [FromBody] string roleName)
        => await ReturnOkIfEverithingIsGood(async () => await userService.AddRoleToUserAsync(new(userId, roleName)));

    [HttpDelete("{userId}/{roleName}")]
    public async Task<IActionResult> DeleteRole(string userId, string roleName)
        => await ReturnOkIfEverithingIsGood(async () => await userService.DeleteRoleFromUserAsync(userId, roleName));
}
