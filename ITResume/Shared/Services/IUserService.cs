using ITResume.Shared.Models.Account;
using ITResume.Shared.Models.Database;
using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;
using ITResume.Shared.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Services;

public interface IUserService : IDbModelService<User, string> 
{
    Task<string?> GetCurrentUserNameAsync();
    Task<bool> IsImpersonating(string userId);

    Task<string?> GetUserIdByUserNameAsync(string userName);
    Task<bool> IsPublicProfile(string userName);
    Task<IEnumerable<User>> GetPublicProfilesAsync();

    Task<User?> GetUserByClaimsAsync(ClaimsPrincipal claims);
    Task<User?> GetUserByNameAsync(string name);
    Task<User> GetUsedUserAsync();
    Task ChangeUsedUserIdAsync(string userId, string usedUserId);
    Task DropUsedUserIdAsync(string userId);

    Task<Contact?> GetCurrentUserContactAsync();

    Task<IEnumerable<Project>> GetCurrentUserProjectsAsync();
    Task<IEnumerable<Employee>> GetCurrentUserEmployeesAsync();
    Task<IEnumerable<Achievement>> GetCurrentUserAchievementsAsync();
    Task<IEnumerable<Technology>> GetCurrentUserTechnologiesAsync();
    Task<IEnumerable<Education>> GetCurrentUserEducationsAsync();
    Task<IEnumerable<ForeignLanguage>> GetCurrentUserForeignLanguagesAsync();
    Task<IEnumerable<ProgrammingLanguage>> GetCurrentUserProgrammingLanguagesAsync();


    Task<Contact?> GetUserContactAsync(string userId);

    Task<IEnumerable<Project>> GetUserProjectsAsync(string userId);
    Task<IEnumerable<Employee>> GetUserEmployeesAsync(string userId);
    Task<IEnumerable<Achievement>> GetUserAchievementsAsync(string userId);
    Task<IEnumerable<Technology>> GetUserTechnologiesAsync(string userId);
    Task<IEnumerable<Education>> GetUserEducationsAsync(string userId);
    Task<IEnumerable<ForeignLanguage>> GetUserForeignLanguagesAsync(string userId);
    Task<IEnumerable<ProgrammingLanguage>> GetUserProgrammingLanguagesAsync(string userId);

    Task ChangeUserPasswordAsync(ChangePassword model);
    Task AddUserPasswordAsync(ModelWithUserId<string> model);
    Task<bool> HasUserPasswordAsync(string userId);
    Task<IEnumerable<string>> GetRolesAsync(string userId);
    Task AddRoleToUserAsync(ModelWithUserId<string> model);
    Task DeleteRoleFromUserAsync(ModelWithUserId<string> model);
}
