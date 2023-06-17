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

    public async Task ChangeUsedUserIdAsync(string userId, string usedUserId)
        => await CheckResponseMessage(await httpClient.PutAsJsonAsync($"{url}/change-usedUserId", new UserAndUsedUser() { UserId = userId, UsedUserId = usedUserId }));

    public async Task DropUsedUserIdAsync(string userId)
        => await CheckResponseMessage(await httpClient.PutAsJsonAsync($"{url}/drop-usedUserId", new UserAndUsedUser() { UserId = userId }));

    public async Task<User> GetUsedUserAsync()
        => (await httpClient.GetFromJsonAsync<User>($"{url}/usedUser"))!;

    public async Task<IEnumerable<Achievement>> GetUserAchievementsAsync()
        => (await httpClient.GetFromJsonAsync<IEnumerable<Achievement>>($"{url}/user-achievements"))!;

    public async Task<User?> GetUserByClaimsAsync(ClaimsPrincipal _ = default!)
        => await CheckModel<User>("current");

    public async Task<User?> GetUserByNameAsync(string name)
        => await CheckModel<User>($"name/{name}");

    public async Task<Contact?> GetUserContactAsync()
        => await CheckModel<Contact>("user-contact");

    public async Task<IEnumerable<Education>> GetUserEducationsAsync()
        => (await httpClient.GetFromJsonAsync<IEnumerable<Education>>($"{url}/user-educations"))!;

    public async Task<IEnumerable<Employee>> GetUserEmployeesAsync()
        => (await httpClient.GetFromJsonAsync<IEnumerable<Employee>>($"{url}/user-employees"))!;

    public async Task<IEnumerable<ForeignLanguage>> GetUserForeignLanguagesAsync()
        => (await httpClient.GetFromJsonAsync<IEnumerable<ForeignLanguage>>($"{url}/user-foreign-languages"))!;

    public async Task<IEnumerable<ProgrammingLanguage>> GetUserProgrammingLanguagesAsync()
        => (await httpClient.GetFromJsonAsync<IEnumerable<ProgrammingLanguage>>($"{url}/user-programming-languages"))!;

    public async Task<IEnumerable<Project>> GetUserProjectsAsync()
        => (await httpClient.GetFromJsonAsync<IEnumerable<Project>>($"{url}/user-projects"))!;

    public async Task<IEnumerable<Technology>> GetUserTechnologiesAsync()
        => (await httpClient.GetFromJsonAsync<IEnumerable<Technology>>($"{url}/user-technologies"))!;

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