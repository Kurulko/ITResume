using ITResume.Server.Database;
using ITResume.Server.Services.ITResumeManagers;
using ITResume.Shared.Models.Database.ITResumeModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Server.Managers.ITResumeManagers;

public class TechnologyManager : ITResumeManager<Technology>, ITechnologyService
{
    public TechnologyManager(ITResumeContext db)
        : base(db) { }

    protected override DbSet<Technology> AllModels()
        => db.Technologies;
}
