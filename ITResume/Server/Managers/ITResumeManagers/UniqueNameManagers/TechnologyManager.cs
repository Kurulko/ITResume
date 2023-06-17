using ITResume.Server.Database;
using ITResume.Server.Managers.ITResumeManagers.UniqueNameManagers;
using ITResume.Server.Services.ITResumeManagers;
using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UniqueNameServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Server.Managers.ITResumeManagers.IUniqueNameManagers;

public class TechnologyManager : UniqueNameManager<Technology>, ITechnologyService
{
    public TechnologyManager(ITResumeContext db)
        : base(db) { }

    protected override DbSet<Technology> AllModels()
        => db.Technologies;
}
