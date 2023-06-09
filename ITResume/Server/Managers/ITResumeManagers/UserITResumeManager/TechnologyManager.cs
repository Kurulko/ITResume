using ITResume.Server.Database;
using ITResume.Server.Services.ITResumeManagers;
using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Server.Managers.ITResumeManagers.UserITResumeManager;

public class TechnologyManager : UserITResumeManager<Technology>, ITechnologyService
{
    public TechnologyManager(ITResumeContext db, IUserService userService)
        : base(db, userService) { }

    protected override DbSet<Technology> AllModels()
        => db.Technologies;
}
