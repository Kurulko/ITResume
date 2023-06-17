using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITResume.Server.Database;
using ITResume.Server.Services.ITResumeManagers;
using Microsoft.EntityFrameworkCore;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UserServices;
using ITResume.Server.Managers.ITResumeManagers.UserITResumeManager;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;

namespace ITResume.Server.Managers.ITResumeManagers.UserITResumeManagers.SkillUserITResumeManagers;

public class EmployeeManager : SkillUserITResumeManager<Employee>, IEmployeeService
{
    public EmployeeManager(ITResumeContext db, IUserService userService)
        : base("EmployeeProgrammingLanguage", "EmployeeTechnology", "EmployeesId", db, userService) { }

    protected override DbSet<Employee> AllModels()
        => db.Employees;

    protected override IQueryable<Employee> GetAllModels()
        => AllModels().Include(p => p.ProgrammingLanguages).Include(p => p.Technologies);
}