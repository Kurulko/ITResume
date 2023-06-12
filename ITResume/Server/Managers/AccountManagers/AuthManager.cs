using ITResume.Shared.Models.Account;
using ITResume.Shared.Models.Database;
using ITResume.Shared;
using Microsoft.AspNetCore.Identity;
using ITResume.Server.Database;
using ITResume.Shared.Services.Account;
using ITResume.Server.Initializers;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ITResume.Shared.Services.ITResumeServices.UserServices;

namespace ITResume.Server.Managers.AccountManagers;

public class AuthManager : IAuthService
{
    readonly SignInManager<User> signInManager;
    readonly UserManager<User> userManager;

    readonly IAchievementService achievementService;
    readonly IContactService contactService;
    readonly IEducationService educationService;
    readonly IProjectService projectService;
    readonly ITechnologyService technologyService;
    readonly IForeignLanguageService foreignLanguageService;
    readonly IEmployeeService employeeService;
    readonly ICompanyService companyService;
    public AuthManager(SignInManager<User> signInManager, UserManager<User> userManager,
         IAchievementService achievementService, IContactService contactService, IEducationService educationService,  IProjectService projectService,  
         ITechnologyService technologyService, IForeignLanguageService foreignLanguageService,  IEmployeeService employeeService,  ICompanyService companyService)
    {
        (this.signInManager, this.userManager) = (signInManager, userManager);

        this.achievementService = achievementService;
        this.contactService = contactService;
        this.educationService = educationService;
        this.projectService = projectService;
        this.technologyService = technologyService;
        this.foreignLanguageService = foreignLanguageService;
        this.employeeService = employeeService;
        this.companyService = companyService;

    }
    //=> (this.signInManager, this.userManager, this.db) = (signInManager, userManager, db);

    public async Task LoginUserAsync(LoginModel login)
    {
        var res = await signInManager.PasswordSignInAsync(login.Name, login.Password, login.RememberMe, false);
        if (!res.Succeeded)
            throw new Exception("Password or/and login invalid");
    }

    public async Task RegisterUserAsync(RegisterModel register)
    {
        User user = (User)register;
        IdentityResult result = await userManager.CreateAsync(user, register.Password);
        if (result.Succeeded)
        {
            user.Registered = DateTime.Now;
            await signInManager.SignInAsync(user, register.RememberMe);
            await userManager.AddToRolesAsync(user, new List<string>() { Roles.User });

            TestDataInitializer dataInitializer = new(achievementService, contactService, educationService, projectService, technologyService, foreignLanguageService, employeeService, companyService);
            await dataInitializer.TestDataInitializeAsync();
        }
        else
            throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));
    }

    public async Task LogoutUserAsync()
        => await signInManager.SignOutAsync();
}
