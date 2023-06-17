using ITResume.Client;
using ITResume.Client.Managers;
using ITResume.Shared.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Syncfusion.Licensing;
using ITResume.Client.Settings;
using Syncfusion.Blazor;
using ITResume.Shared.Models.Database;
using ITResume.Client.Managers.AccountManagers;
using ITResume.Shared.Services.Account;
using ITResume.Shared.Services.ITResumeServices.UserServices;
using ITResume.Client.Managers.ITResumeManagers.UserITResumeManagers;
using ITResume.Client.Managers.ITResumeManagers.UserITResumeManagers.SkillITResumeDbModelManager;
using ITResume.Shared.Services.ITResumeServices.UniqueNameServices;
using ITResume.Client.Managers.ITResumeManagers.UniqueNameServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

SyncfusionLicenseProvider.RegisterLicense(SyncfusionSettings.LicenseKey);


IServiceCollection services = builder.Services;

services.AddHttpContextAccessor();

services.AddScoped<IAchievementService, AchievementManager>();
services.AddScoped<IContactService, ContactManager>();
services.AddScoped<IEducationService, EducationManager>();
services.AddScoped<IProjectService, ProjectManager>();
services.AddScoped<ITechnologyService, TechnologyManager>();
services.AddScoped<ICountryService, CountryManager>();
services.AddScoped<IProgrammingLanguageService, ProgrammingLanguageManager>();
services.AddScoped<IHumanLanguageService, HumanLanguageManager>();
services.AddScoped<IForeignLanguageService, ForeignLanguageManager>();
services.AddScoped<IEmployeeService, EmployeeManager>();
services.AddScoped<ICompanyService, CompanyManager>();
services.AddScoped<IAuthService, AuthManager>();
services.AddScoped<IRoleService, RoleManager>();
services.AddScoped<IUserService, UserManager>();

services.AddOptions();
services.AddAuthorizationCore();
services.AddScoped<CustomStateProvider>();
services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomStateProvider>());
services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
services.AddSyncfusionBlazor();


await builder.Build().RunAsync();
