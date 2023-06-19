using ITResume.Client.Managers.ITResumeManagers;
using ITResume.Shared.Models.Account;
using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;
using ITResume.Shared.Models.ViewModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Project = ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels.Project;
using User = ITResume.Shared.Models.Database.User;

namespace ITResume.Client.Managers;

public class UserManager : DbModelManager<User, string>, IUserService
{
    public UserManager(HttpClient httpClient) : base(httpClient, "users") { }

    public async Task<string?> GetUserIdByUserNameAsync(string userName)
        => await CheckModel($"userid-by-name/{userName}");

    public async Task<bool> IsPublicProfile(string userName)
        => await CheckModel<bool>($"is-public-profile/{userName}");

    public async Task<IEnumerable<User>> GetPublicProfilesAsync()
        => (await httpClient.GetFromJsonAsync<IEnumerable<User>>($"{url}/public-profiles"))!;

    public async Task ChangeUsedUserIdAsync(string userId, string usedUserId)
        => await CheckResponseMessage(await httpClient.PutAsJsonAsync($"{url}/change-usedUserId", new UserAndUsedUser() { UserId = userId, UsedUserId = usedUserId }));

    public async Task DropUsedUserIdAsync(string userId)
        => await CheckResponseMessage(await httpClient.PutAsJsonAsync($"{url}/drop-usedUserId", new UserAndUsedUser() { UserId = userId }));

    public async Task<User> GetUsedUserAsync()
        => (await httpClient.GetFromJsonAsync<User>($"{url}/usedUser"))!;


    public async Task<User?> GetUserByClaimsAsync(ClaimsPrincipal _ = default!)
        => await CheckModel<User>("current");

    public async Task<User?> GetUserByNameAsync(string name)
        => await CheckModel<User>($"name/{name}");

    public async Task<string?> GetCurrentUserNameAsync()
        => await CheckModel("current-username");

    public async Task<bool> IsImpersonating(string userId)
        => (await httpClient.GetFromJsonAsync<bool>($"{url}/{userId}/is-impersonating"))!;


    const string userContact = "user-contact", userAchievements = "user-achievements", userEducations = "user-educations"
    , userEmployees = "user-employees", userProgrammingLanguages = "user-programming-languages", userForeignLanguages = "user-foreign-languages"
    , userProjects = "user-projects", userTechnologies = "user-technologies";

    public async Task<Contact?> GetCurrentUserContactAsync()
        => await CheckModel<Contact>(userContact);

    public async Task<IEnumerable<Achievement>> GetCurrentUserAchievementsAsync()
        => (await httpClient.GetFromJsonAsync<IEnumerable<Achievement>>($"{url}/{userAchievements}"))!;

    public async Task<IEnumerable<Education>> GetCurrentUserEducationsAsync()
        => (await httpClient.GetFromJsonAsync<IEnumerable<Education>>($"{url}/{userEducations}"))!;

    public async Task<IEnumerable<Employee>> GetCurrentUserEmployeesAsync()
        => (await httpClient.GetFromJsonAsync<IEnumerable<Employee>>($"{url}/{userEmployees}"))!;

    public async Task<IEnumerable<ForeignLanguage>> GetCurrentUserForeignLanguagesAsync()
        => (await httpClient.GetFromJsonAsync<IEnumerable<ForeignLanguage>>($"{url}/{userForeignLanguages}"))!;

    public async Task<IEnumerable<ProgrammingLanguage>> GetCurrentUserProgrammingLanguagesAsync()
        => (await httpClient.GetFromJsonAsync<IEnumerable<ProgrammingLanguage>>($"{url}/{userProgrammingLanguages}"))!;

    public async Task<IEnumerable<Project>> GetCurrentUserProjectsAsync()
        => (await httpClient.GetFromJsonAsync<IEnumerable<Project>>($"{url}/{userProjects}"))!;

    public async Task<IEnumerable<Technology>> GetCurrentUserTechnologiesAsync()
        => (await httpClient.GetFromJsonAsync<IEnumerable<Technology>>($"{url}/{userTechnologies}"))!;


    public async Task<Contact?> GetUserContactAsync(string userId)
    => await CheckModel<Contact>($"{userContact}/{userId}");

    public async Task<IEnumerable<Achievement>> GetUserAchievementsAsync(string userId)
    => (await httpClient.GetFromJsonAsync<IEnumerable<Achievement>>($"{url}/{userAchievements}/{userId}"))!;

    public async Task<IEnumerable<Education>> GetUserEducationsAsync(string userId)
        => (await httpClient.GetFromJsonAsync<IEnumerable<Education>>($"{url}/{userEducations}/{userId}"))!;

    public async Task<IEnumerable<Employee>> GetUserEmployeesAsync(string userId)
        => (await httpClient.GetFromJsonAsync<IEnumerable<Employee>>($"{url}/{userEmployees}/{userId}"))!;

    public async Task<IEnumerable<ForeignLanguage>> GetUserForeignLanguagesAsync(string userId)
        => (await httpClient.GetFromJsonAsync<IEnumerable<ForeignLanguage>>($"{url}/{userForeignLanguages}/{userId}"))!;

    public async Task<IEnumerable<ProgrammingLanguage>> GetUserProgrammingLanguagesAsync(string userId)
        => (await httpClient.GetFromJsonAsync<IEnumerable<ProgrammingLanguage>>($"{url}/{userProgrammingLanguages}/{userId}"))!;

    public async Task<IEnumerable<Project>> GetUserProjectsAsync(string userId)
        => (await httpClient.GetFromJsonAsync<IEnumerable<Project>>($"{url}/{userProjects}/{userId}"))!;

    public async Task<IEnumerable<Technology>> GetUserTechnologiesAsync(string userId)
        => (await httpClient.GetFromJsonAsync<IEnumerable<Technology>>($"{url}/{userTechnologies}/{userId}"))!;


    public async Task ChangeUserPasswordAsync(ChangePassword model)
        => await CheckResponseMessage(await httpClient.PutAsJsonAsync($"{url}/password", model));

    public async Task AddUserPasswordAsync(ModelWithUserId<string> model)
        => await CheckResponseMessage(await httpClient.PostAsJsonAsync($"{url}/password", model));

    public async Task<bool> HasUserPasswordAsync(string userId)
         => (await httpClient.GetFromJsonAsync<bool>($"{url}/{userId}/password"))!;

    public async Task<IEnumerable<string>> GetRolesAsync(string userId)
        => (await httpClient.GetFromJsonAsync<IEnumerable<string>>($"{url}/{userId}/roles"))!;

    public async Task AddRoleToUserAsync(ModelWithUserId<string> model)
        => await CheckResponseMessage(await httpClient.PostAsJsonAsync($"{url}/{model.UserId}/role", model.Model));

    public async Task DeleteRoleFromUserAsync(ModelWithUserId<string> model)
        => await CheckResponseMessage(await httpClient.DeleteAsync($"{url}/{model.UserId}/{model.Model}"));
}