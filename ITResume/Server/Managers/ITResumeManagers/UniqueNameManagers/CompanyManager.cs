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

public class CompanyManager : UniqueNameManager<Company>, ICompanyService
{
    public CompanyManager(ITResumeContext db) : base(db) { }
    
    protected override DbSet<Company> AllModels()
        => db.Companies;

    protected override IQueryable<Company> GetAllModels()
        => AllModels().Include(c => c.Employees)!.ThenInclude(e => e.ProgrammingLanguages)
            .Include(e => e.Employees)!.ThenInclude(e => e.ProgrammingLanguages)
            .Include(e => e.Employees)!.ThenInclude(e => e.User);
}