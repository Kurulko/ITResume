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
    Task<User?> GetUserByClaimsAsync(ClaimsPrincipal claims);
    Task<User?> GetUserByNameAsync(string name);
    Task<User> GetUsedUserAsync();
    Task ChangeUsedUserIdAsync(string userId, string usedUserId);
    Task DropUsedUserIdAsync(string userId);

    Task<Contact?> GetUserContactAsync();

    Task<IEnumerable<Project>> GetUserProjectsAsync();
    Task<IEnumerable<Employee>> GetUserEmployeesAsync();
    Task<IEnumerable<Achievement>> GetUserAchievementsAsync();
    Task<IEnumerable<Technology>> GetUserTechnologiesAsync();
    Task<IEnumerable<Education>> GetUserEducationsAsync();
    Task<IEnumerable<ForeignLanguage>> GetUserForeignLanguagesAsync();
    Task<IEnumerable<ProgrammingLanguage>> GetUserProgrammingLanguagesAsync();

    Task ChangeUserPasswordAsync(ChangePassword model);
    Task AddUserPasswordAsync(ModelWithUserId<string> model);
    Task<bool> HasUserPasswordAsync(string userId);
    Task<IEnumerable<string>> GetRolesAsync(string userId);
    Task AddRoleToUserAsync(ModelWithUserId<string> model);
    Task DeleteRoleFromUserAsync(ModelWithUserId<string> model);
}
