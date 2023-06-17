using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ITResume.Client.Managers.ITResumeManagers;
using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Services.ITResumeServices.UniqueNameServices;
using ITResume.Client.Managers.ITResumeManagers.UniqueNameManagers;

namespace ITResume.Client.Managers.ITResumeManagers.UniqueNameServices;

public class HumanLanguageManager : UniqueNameManager<HumanLanguage>, IHumanLanguageService
{
    public HumanLanguageManager(HttpClient httpClient) : base(httpClient, "human-languages") { }
}