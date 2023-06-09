using ITResume.Server.Database;
using ITResume.Server.Initializers;
using ITResume.Server.Managers.AccountManagers;
using ITResume.Server.Managers.ITResumeManagers;
using ITResume.Server.Managers.ITResumeManagers.UserITResumeManager;
using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using ITResume.Shared.Services.Account;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;

IServiceCollection services = builder.Services;

string connection = config.GetConnectionString("DefaultConnection");
services.AddDbContext<ITResumeContext>(opts =>
{
    opts.UseSqlServer(connection);
    opts.EnableSensitiveDataLogging();
});

services.AddIdentity<User, Role>().AddEntityFrameworkStores<ITResumeContext>();
services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opts =>
{
    opts.Cookie.HttpOnly = false;
    opts.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});
services.AddHttpContextAccessor();

services.AddScoped<IRoleService, ITResume.Server.Managers.RoleManager>();
services.AddScoped<IUserService, ITResume.Server.Managers.UserManager>();

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

services.AddControllers().AddNewtonsoftJson(options =>
      options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
   );;
services.AddSwaggerGen();
services.AddRazorPages();


WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

using (IServiceScope serviceScope = app.Services.CreateScope())
{
    IServiceProvider serviceProvider = serviceScope.ServiceProvider;

    var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
    await RolesInitializer.InitializeAsync(roleManager);

    string adminName = config.GetValue<string>("Admin:Name");
    string adminPassword = config.GetValue<string>("Admin:Password");
    var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
    await UsersInitializer.AdminInitializeAsync(userManager, adminName, adminPassword);
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();