using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITResume.Server.Database;
using ITResume.Server.Services.ITResumeManagers;
using Microsoft.EntityFrameworkCore;
using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Services.ITResumeServices.UniqueNameServices;
using ITResume.Server.Managers.ITResumeManagers.UniqueNameManagers;

namespace ITResume.Server.Managers.ITResumeManagers.IUniqueNameManagers;

public class CountryManager : UniqueNameManager<Country>, ICountryService
{
    public CountryManager(ITResumeContext db) : base(db) { }

    protected override DbSet<Country> AllModels()
        => db.Countries;
}