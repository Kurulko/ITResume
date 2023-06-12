﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITResume.Shared.Services.ITResumeServices;
using ITResume.Server.Database;
using ITResume.Server.Services.ITResumeManagers;
using Microsoft.EntityFrameworkCore;
using ITResume.Shared.Models.Database.ITResumeModels;

namespace ITResume.Server.Managers.ITResumeManagers;

public class CompanyManager : ITResumeManager<Company>, ICompanyService
{
    public CompanyManager(ITResumeContext db) : base(db) { }

    protected override DbSet<Company> AllModels()
        => db.Companies;
}