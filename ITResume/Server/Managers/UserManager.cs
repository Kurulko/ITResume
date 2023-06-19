using ITResume.Server.Database;
using ITResume.Shared;
using ITResume.Shared.Models.Account;
using ITResume.Shared.Models.Database;
using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;
using ITResume.Shared.Models.ViewModels;
using ITResume.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Project = ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels.Project;
using User = ITResume.Shared.Models.Database.User;

namespace ITResume.Server.Managers;

public class UserManager : IUserService
{
    readonly UserManager<User> userManager;
    readonly IHttpContextAccessor httpContextAccessor;
    readonly ITResumeContext db;
    public UserManager(UserManager<User> userManager, ITResumeContext db, IHttpContextAccessor httpContextAccessor)
    {
        (this.userManager, this.httpContextAccessor, this.db) = (userManager, httpContextAccessor, db);
        getModels = db.Users;
    }

    public async Task<User> AddModelAsync(User model)
    {
        await userManager.CreateAsync(model);
        return model;
    }

    public async Task UpdateModelAsync(User model)
    {
        db.Entry(model).State = EntityState.Modified;

        var userDetails = model.UserDetails;
        if (userDetails is not null)
            db.Entry(userDetails).State = EntityState.Modified;

        await db.SaveChangesAsync();
    }

    public async Task ChangeUsedUserIdAsync(string userId, string usedUserId)
    {
        User? user = await GetModelByIdAsync(userId);
        if (user is not null && !string.IsNullOrEmpty(usedUserId))
        {
            user.UsedUserId = usedUserId;
            await UpdateModelAsync(user);
        }
    }

    public async Task DeleteModelAsync(string key)
    {
        User? user = await GetModelByIdAsync(key);
        if (user is not null)
            await userManager.DeleteAsync(user);
    }

    public async Task DropUsedUserIdAsync(string userId)
    {
        User? user = await GetModelByIdAsync(userId);
        if (user is not null)
        {
            user.UsedUserId = null;
            await UpdateModelAsync(user);
        }
    }

    IQueryable<User> getModels;

    public async Task<IEnumerable<User>> GetAllModelsAsync()
    {
        getModels = getModels.Include(u => u.UserDetails);
        return await getModels.ToListAsync();
    }

    public async Task<IEnumerable<User>> GetPublicProfilesAsync()
        => (await GetAllModelsAsync()).Where(u => u.UserDetails?.IsPublicProfile ?? false);

    public async Task<User?> GetModelByIdAsync(string key)
        => await getModels.Include(u => u.UserDetails).FirstOrDefaultAsync(u => u.Id == key);

    public async Task<User?> GetUserByClaimsAsync(ClaimsPrincipal claims)
        => await GetModelByIdAsync(claims.FindFirstValue(ClaimTypes.NameIdentifier)!);

    public async Task<string?> GetUserIdByUserNameAsync(string userName)
        => (await GetUserByNameAsync(userName))?.Id;

    public async Task<bool> IsPublicProfile(string userName)
        => (await GetUserByNameAsync(userName))?.UserDetails?.IsPublicProfile ?? false;

    public async Task<IEnumerable<Achievement>> GetCurrentUserAchievementsAsync()
    {
        getModels = getModels.Include(u => u.Achievements);
        return (await GetUsedUserAsync()).Achievements!;
    }

    public async Task<Contact?> GetCurrentUserContactAsync()
    {
        getModels = getModels.Include(u => u.Contact).ThenInclude(c => c!.Country);
        return (await GetUsedUserAsync()).Contact!;
    }

    public async Task<IEnumerable<Education>> GetCurrentUserEducationsAsync()
    {
        getModels = getModels.Include(u => u.Educations)!.ThenInclude(c => c.Country);
        return (await GetUsedUserAsync()).Educations!;
    }

    public async Task<IEnumerable<Employee>> GetCurrentUserEmployeesAsync()
    {
        getModels = getModels.Include(u => u!.Employees)!.ThenInclude(c => c!.Company)!.Include(u => u!.Employees)!.ThenInclude(u => u!.Technologies)!.Include(u => u!.Employees)!.ThenInclude(u => u.ProgrammingLanguages);
        return (await GetUsedUserAsync()).Employees!;
    }

    public async Task<IEnumerable<ForeignLanguage>> GetCurrentUserForeignLanguagesAsync()
    {
        getModels = getModels.Include(u => u.ForeignLanguages)!.ThenInclude(c => c.HumanLanguage);
        return (await GetUsedUserAsync()).ForeignLanguages!;
    }

    public async Task<IEnumerable<ProgrammingLanguage>> GetCurrentUserProgrammingLanguagesAsync()
    {
        getModels = getModels.Include(u => u.ProgrammingLanguages);
        return (await GetUsedUserAsync()).ProgrammingLanguages!;
    }

    public async Task<IEnumerable<Project>> GetCurrentUserProjectsAsync()
    {
        getModels = getModels.Include(u => u.Projects)!.ThenInclude(c => c.ProgrammingLanguages)!.Include(u => u.Projects)!.ThenInclude(u => u.Technologies);
        return (await GetUsedUserAsync()).Projects!;
    }

    public async Task<IEnumerable<Technology>> GetCurrentUserTechnologiesAsync()
    {
        getModels = getModels.Include(u => u.Technologies);
        return (await GetUsedUserAsync()).Technologies!;
    }


    public async Task<User> GetUsedUserAsync()
    {
        var claims = httpContextAccessor.HttpContext!.User;
        User currentUser = (await GetUserByClaimsAsync(claims))!;

        string? usedUserId = currentUser.UsedUserId;
        if (string.IsNullOrEmpty(usedUserId))
            return currentUser;

        User? usedUser = await GetModelByIdAsync(usedUserId);
        return usedUser is null ? currentUser : usedUser;
    }

    public async Task<User?> GetUserByNameAsync(string name)
    {
        getModels = getModels.Include(u => u.UserDetails);
        return await getModels.FirstOrDefaultAsync(u => u.UserName!.ToLower() == name.ToLower());
    }


    public async Task AddRoleToUserAsync(ModelWithUserId<string> model)
    {
        string roleName = model.Model;
        User user = await GetUserByIdAsync(model.UserId);
        IdentityResult res = await userManager.AddToRoleAsync(user, roleName);
        if (!res.Succeeded)
            throw new Exception(string.Join("; ", res.Errors.Select(e => e.Description)));
    }

    public async Task AddUserPasswordAsync(ModelWithUserId<string> model)
    {
        string newPassword = model.Model;
        User user = await GetUserByIdAsync(model.UserId);
        IdentityResult res = await userManager.AddPasswordAsync(user, newPassword);
        if (!res.Succeeded)
            throw new Exception(string.Join("; ", res.Errors.Select(e => e.Description)));
    }

    public async Task ChangeUserPasswordAsync(ChangePassword model)
    {
        ChangePassword password = model;
        User user = await GetUsedUserAsync();
        IdentityResult res = await userManager.ChangePasswordAsync(user, password.OldPassword!, password.NewPassword);
        if (!res.Succeeded)
            throw new Exception(string.Join("; ", res.Errors.Select(e => e.Description)));
    }

    public async Task DeleteRoleFromUserAsync(ModelWithUserId<string> model)
    {
        User user = await GetUserByIdAsync(model.UserId);
        IdentityResult res = await userManager.RemoveFromRoleAsync(user, model.Model);
        if (!res.Succeeded)
            throw new Exception(string.Join("; ", res.Errors.Select(e => e.Description)));
    }

    public async Task<bool> HasUserPasswordAsync(string userId)
    {
        User? user = await GetUserByIdAsync(userId);
        return await userManager.HasPasswordAsync(user);
    }

    public async Task<IEnumerable<string>> GetRolesAsync(string userId)
    {
        User? user = await GetUserByIdAsync(userId);
        return await userManager.GetRolesAsync(user!);
    }

    async Task<User> GetUserByIdAsync(string userId)
    {
        User? user = await GetModelByIdAsync(userId);
        if (user is null)
            throw new ArgumentException($"The user with id '{userId}' doesn't exist");
        return user!;
    }


    async Task<User> GetPublicUserProfileById(string userId)
    {
        var claims = httpContextAccessor.HttpContext?.User;

        User user = await GetUserByIdAsync(userId);

        bool isItCurrentUser = false, isAdmin = false;
        if (claims?.Identity?.IsAuthenticated ?? false)
        {
            User currentUser = await GetUsedUserAsync();
            isItCurrentUser = currentUser.Id == userId;
            isAdmin = claims.IsInRole(Roles.Admin);
        }

        if ((user.UserDetails?.IsPublicProfile ?? false) || isItCurrentUser || isAdmin)
            return user;
        throw new AccessViolationException();
    }

    public async Task<Contact?> GetUserContactAsync(string userId)
    {
        getModels = getModels.Include(u => u.Contact).ThenInclude(c => c!.Country);
        return (await GetPublicUserProfileById(userId)).Contact!;
    }

    public async Task<IEnumerable<Achievement>> GetUserAchievementsAsync(string userId)
    {
        getModels = getModels.Include(u => u.Achievements);
        return (await GetPublicUserProfileById(userId)).Achievements!;
    }

    public async Task<IEnumerable<Project>> GetUserProjectsAsync(string userId)
    {
        getModels = getModels.Include(u => u.Projects)!.ThenInclude(c => c.ProgrammingLanguages)!.Include(u => u.Projects)!.ThenInclude(u => u.Technologies);
        return (await GetPublicUserProfileById(userId)).Projects!;
    }

    public async Task<IEnumerable<Employee>> GetUserEmployeesAsync(string userId)
    {
        getModels = getModels.Include(u => u!.Employees)!.ThenInclude(c => c!.Company)!.Include(u => u!.Employees)!.ThenInclude(u => u!.Technologies)!.Include(u => u!.Employees)!.ThenInclude(u => u.ProgrammingLanguages);
        return (await GetPublicUserProfileById(userId)).Employees!;
    }

    public async Task<IEnumerable<Technology>> GetUserTechnologiesAsync(string userId)
    {
        getModels = getModels.Include(u => u.Technologies);
        return (await GetPublicUserProfileById(userId)).Technologies!;
    }

    public async Task<IEnumerable<Education>> GetUserEducationsAsync(string userId)
    {
        getModels = getModels.Include(u => u.Educations)!.ThenInclude(c => c.Country);
        return (await GetPublicUserProfileById(userId)).Educations!;
    }

    public async Task<IEnumerable<ForeignLanguage>> GetUserForeignLanguagesAsync(string userId)
    {
        getModels = getModels.Include(u => u.ForeignLanguages)!.ThenInclude(c => c.HumanLanguage);
        return (await GetPublicUserProfileById(userId)).ForeignLanguages!;
    }

    public async Task<IEnumerable<ProgrammingLanguage>> GetUserProgrammingLanguagesAsync(string userId)
    {
        getModels = getModels.Include(u => u.ProgrammingLanguages);
        return (await GetPublicUserProfileById(userId)).ProgrammingLanguages!;
    }

    public async Task<string?> GetCurrentUserNameAsync()
        => (await GetUsedUserAsync())?.UserName;

    public async Task<bool> IsImpersonating(string userId)
        => !string.IsNullOrEmpty((await GetModelByIdAsync(userId))?.UsedUserId);
}
