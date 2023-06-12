using ITResume.Server.Database;
using ITResume.Shared.Models.Account;
using ITResume.Shared.Models.Database;
using ITResume.Shared.Models.Database.ITResumeModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Models.ViewModels;
using ITResume.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ITResume.Server.Managers;

public class UserManager : IUserService
{
    readonly UserManager<User> userManager;
    readonly ITResumeContext db;
    readonly IHttpContextAccessor httpContextAccessor;
    public UserManager(UserManager<User> userManager, ITResumeContext db, IHttpContextAccessor httpContextAccessor)
    {
        (this.userManager, this.db, this.httpContextAccessor) = (userManager, db, httpContextAccessor);
        getModels = db.Users;
    }

    public async Task AddModelAsync(User model)
    {
        await db.Users.AddAsync(model);
        db.SaveChanges();
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


    public async Task<User?> GetModelByIdAsync(string key)
    {
        getModels = getModels.Include(u => u.UserDetails);
        return await getModels.FirstOrDefaultAsync(u => u.Id == key);
    }

    public async Task<User?> GetUserByClaimsAsync(ClaimsPrincipal claims)
        => await GetModelByIdAsync(claims.FindFirstValue(ClaimTypes.NameIdentifier)!);

    public async Task<IEnumerable<Achievement>> GetUserAchievementsAsync()
    {
        getModels = getModels.Include(u => u.Achievements);
        return (await GetUsedUserAsync()).Achievements!;
    }

    public async Task<Contact?> GetUserContactAsync()
    {
        getModels = getModels.Include(u => u.Contact).ThenInclude(c => c!.Country);
        return (await GetUsedUserAsync()).Contact!;
    }

    public async Task<IEnumerable<Education>> GetUserEducationsAsync()
    {
        getModels = getModels.Include(u => u.Educations)!.ThenInclude(c => c.Country);
        return (await GetUsedUserAsync()).Educations!;
    }

    public async Task<IEnumerable<Employee>> GetUserEmployeesAsync()
    {
        getModels = getModels.Include(u => u!.Employees)!.ThenInclude(c => c!.Company)!.Include(u => u!.Employees)!.ThenInclude(u => u!.Technologies)!.Include(u => u!.Employees)!.ThenInclude(u => u.ProgrammingLanguages);
        return (await GetUsedUserAsync()).Employees!;
    }

    public async Task<IEnumerable<ForeignLanguage>> GetUserForeignLanguagesAsync()
    {
        getModels = getModels.Include(u => u.ForeignLanguages)!.ThenInclude(c => c.HumanLanguage);
        return (await GetUsedUserAsync()).ForeignLanguages!;
    }

    public async Task<IEnumerable<ProgrammingLanguage>> GetUserProgrammingLanguagesAsync()
    {
        getModels = getModels.Include(u => u.ProgrammingLanguages);
        return (await GetUsedUserAsync()).ProgrammingLanguages!;
    }

    public async Task<IEnumerable<Project>> GetUserProjectsAsync()
    {
        getModels = getModels.Include(u => u.Projects)!.ThenInclude(c => c.ProgrammingLanguages)!.Include(u => u.Projects)!.ThenInclude(u => u.Technologies);
        return (await GetUsedUserAsync()).Projects!;
    }

    public async Task<IEnumerable<Technology>> GetUserTechnologiesAsync()
    {
        getModels = getModels.Include(u => u.Technologies);
        return (await GetUsedUserAsync()).Technologies!;
    }


    public async Task UpdateModelAsync(User model)
        => await userManager.UpdateAsync(model);

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

    public async Task AddUserPasswordAsync(ModelWithUserId<ChangePassword> model)
    {

        ChangePassword password = model.Model;
        User user = await GetUserByIdAsync(model.UserId);
        IdentityResult res = await userManager.AddPasswordAsync(user, password.NewPassword);
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

    public async Task DeleteRoleFromUserAsync(string userId, string roleName)
    {
        User user = await GetUserByIdAsync(userId);
        IdentityResult res = await userManager.RemoveFromRoleAsync(user, roleName);
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
}
