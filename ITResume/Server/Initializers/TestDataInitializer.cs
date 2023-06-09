using ITResume.Server.Managers.ITResumeManagers.UserITResumeManager;
using ITResume.Server.Services.ITResumeManagers;
using ITResume.Shared.Enums;
using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Identity;

namespace ITResume.Server.Initializers;

public class TestDataInitializer
{
    readonly IAchievementService achievementService;
    readonly IContactService contactService;
    readonly IEducationService educationService;
    readonly IProjectService projectService;
    readonly ITechnologyService technologyService;
    readonly IForeignLanguageService foreignLanguageService;
    readonly IEmployeeService employeeService;
    readonly ICompanyService companyService;

    public TestDataInitializer(IAchievementService achievementService, IContactService contactService, IEducationService educationService,
        IProjectService projectService, ITechnologyService technologyService, IForeignLanguageService foreignLanguageService, IEmployeeService employeeService, ICompanyService companyService)
    {
        this.achievementService = achievementService;
        this.contactService = contactService;
        this.educationService = educationService;
        this.projectService = projectService;
        this.technologyService = technologyService;
        this.foreignLanguageService = foreignLanguageService;
        this.employeeService = employeeService;
        this.companyService = companyService;
    }

    public async Task TestDataInitializeAsync()
    {
        await AchievementsInitializeAsync();
        await ContactInitializeAsync();
        await EducationsInitializeAsync();
        await ProjectsInitializeAsync();
        await TechnologiesInitializeAsync();
        await ForeignLanguagesInitializeAsync();
        await CompanyInitializeAsync();
        await EmployeesInitializeAsync();
    }

    async Task EmployeesInitializeAsync()
    {
        for (int i = 0; i < 9; i++)
        {
            Employee employee = new()
            {
                Description = $"Description{i}",
                StartWorking = DateTime.Now.AddDays(new Random().Next(100)),
                FinishWorking = DateTime.Now.AddDays(-1 * new Random().Next(100)),
                Salary = new Random().Next(100000),
                CompanyId = 1,
            };
            await employeeService.AddModelAsync(employee);
        }
    }
    async Task ForeignLanguagesInitializeAsync()
    {
        for (int i = 0; i < 10; i++)
        {
            ForeignLanguage foreignLanguage= new()
            {
                HumanLanguageId = new Random().Next(100) + 1,
                LanguageLevel = (LanguageLevel)new Random().Next(Enum.GetValues<LanguageLevel>().Length),
            };
            await foreignLanguageService.AddModelAsync(foreignLanguage);
        }
    }
    async Task TechnologiesInitializeAsync()
    {
        for (int i = 0; i < 120; i++)
        {
            Technology technology = new()
            {
                Name = $"Name{i}",
                Description = $"Description{i}",
                Link = $"https://somesite/{i}",
            };
            await technologyService.AddModelAsync(technology);
        }
    }
    async Task AchievementsInitializeAsync()
    {
        for (int i = 0; i < 50; i++)
        {
            Achievement achievement = new()
            {
                Description = $"Description{i}",
                Link = $"https://somesite/{i}",
                Name = $"Name{i}",
                When = DateTime.Now.AddDays(-1 * new Random().Next(100)),
            };
            await achievementService.AddModelAsync(achievement);
        }
    }
    async Task EducationsInitializeAsync()
    {
        for (int i = 0; i < 5; i++)
        {
            Education education = new()
            {
                University = $"University{i}",
                Specialty = $"Specialty{i}",
                Faculty = $"Faculty{i}",
                DegreeOfEducation = (DegreeOfEducation)new Random().Next(Enum.GetValues<DegreeOfEducation>().Length),
                TypeOfEducation = (TypeOfEducation)new Random().Next(Enum.GetValues<TypeOfEducation>().Length),
                StartEducation = DateTime.Now.AddDays(new Random().Next(100)),
                FinishEducation = DateTime.Now.AddDays(-1 * new Random().Next(100)),
                CountryId = new Random().Next(100) + 1,
            };
            await educationService.AddModelAsync(education);
        }
    }
    async Task ProjectsInitializeAsync()
    {
        for (int i = 0; i < 47; i++)
        {
            Project project = new()
            {
                Name = $"Name{i}",
                Description = $"Description{i}",
                WorkExample = $"https://WorkExample/{i}",
                Link = $"https://somesite/{i}",
                Github = $"https://Github/{i}",
                StartDoing = DateTime.Now.AddDays(new Random().Next(100)),
                FinishDoing = DateTime.Now.AddDays(-1 * new Random().Next(100)),
            };
            await projectService.AddModelAsync(project);
        }
    }

    async Task ContactInitializeAsync()
    {
        int randomNumber = new Random().Next(50);
        Contact contact = new()
        {
            Address = $"Address{randomNumber}",
            City = $"City{randomNumber}",
            Email = $"hz{randomNumber}@gmail.com",
            Github = $"https://Github/{randomNumber}",
            Habr = $"https://Habr/{randomNumber}",
            LinkedId = $"https://LinkedId/{randomNumber}",
            MobilePhone = $"38073895426{randomNumber}",
            Stackoverflow = $"https://Stackoverflow/{randomNumber}",
            Telegram = $"User{randomNumber}",
        };
        await contactService.AddModelAsync(contact);
    }

    async Task CompanyInitializeAsync()
    {
        int randomNumber = new Random().Next(50);
        Company company = new()
        {
            Name = $"Name{randomNumber}",
            Description = $"Description{randomNumber}",
            CountryId = randomNumber + 1,
            StartWorking = DateTime.Now.AddDays(new Random().Next(100)),
            FinishWorking = DateTime.Now.AddDays(-1 * new Random().Next(100)),
        };
        await companyService.AddModelAsync(company);
    }

}
