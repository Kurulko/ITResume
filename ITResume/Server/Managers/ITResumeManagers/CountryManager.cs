using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITResume.Shared.Services.ITResumeServices;
using ITResume.Server.Database;
using ITResume.Server.Services.ITResumeManagers;
using Microsoft.EntityFrameworkCore;
using ITResume.Shared.Models.Database;

namespace ITResume.Server.Managers.ITResumeManagers;

public class CountryManager : ITResumeManager<Country>, ICountryService
{
    public CountryManager(ITResumeContext db) : base(db) { }

    protected override DbSet<Country> AllModels()
        => db.Countries;
}