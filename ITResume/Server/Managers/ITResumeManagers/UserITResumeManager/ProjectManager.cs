using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITResume.Server.Database;
using Microsoft.EntityFrameworkCore;
using ITResume.Server.Services.ITResumeManagers;
using ITResume.Shared.Services;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Services.ITResumeServices.UserServices;

namespace ITResume.Server.Managers.ITResumeManagers.UserITResumeManager;

public class ProjectManager : UserITResumeManager<Project>, IProjectService
{
    public ProjectManager(ITResumeContext db, IUserService userService)
        : base(db, userService) { }

    protected override DbSet<Project> AllModels()
        => db.Projects;

    protected override IQueryable<Project> GetAllModels()
        => AllModels().Include(p => p.ProgrammingLanguages).Include(p => p.Technologies);
}