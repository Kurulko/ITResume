using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITResume.Server.Database;
using Microsoft.EntityFrameworkCore;
using ITResume.Server.Services.ITResumeManagers;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UserServices;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using ITResume.Shared.Models.Database.ITResumeModels;
using ITResume.Server.Managers.ITResumeManagers.UserITResumeManager;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;

namespace ITResume.Server.Managers.ITResumeManagers.UserITResumeManagers.SkillUserITResumeManagers;

public class ProjectManager : SkillUserITResumeManager<Project>, IProjectService
{
    public ProjectManager(ITResumeContext db, IUserService userService)
        : base("ProgrammingLanguageProject", "ProjectTechnology", "ProjectsId", db, userService) { }

    protected override DbSet<Project> AllModels()
        => db.Projects;

    protected override IQueryable<Project> GetAllModels()
        => AllModels().Include(p => p.ProgrammingLanguages).Include(p => p.Technologies);
}