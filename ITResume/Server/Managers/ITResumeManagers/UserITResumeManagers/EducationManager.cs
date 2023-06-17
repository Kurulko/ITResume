using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITResume.Server.Database;
using ITResume.Server.Services.ITResumeManagers;
using Microsoft.EntityFrameworkCore;
using ITResume.Shared.Services;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Services.ITResumeServices.UserServices;

namespace ITResume.Server.Managers.ITResumeManagers.UserITResumeManager;

public class EducationManager : UserITResumeManager<Education>, IEducationService
{
    public EducationManager(ITResumeContext db, IUserService userService)
        : base(db, userService) { }

    protected override DbSet<Education> AllModels()
        => db.Educations;
}