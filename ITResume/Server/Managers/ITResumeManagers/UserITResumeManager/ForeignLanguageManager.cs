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
using ITResume.Shared.Services;

namespace ITResume.Server.Managers.ITResumeManagers.UserITResumeManager;

public class ForeignLanguageManager : UserITResumeManager<ForeignLanguage>, IForeignLanguageService
{
    public ForeignLanguageManager(ITResumeContext db, IUserService userService)
        : base(db, userService) { }

    protected override DbSet<ForeignLanguage> AllModels()
        => db.ForeignLanguages;
}