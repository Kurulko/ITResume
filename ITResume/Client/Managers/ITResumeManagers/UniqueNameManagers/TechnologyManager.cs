using ITResume.Client.Managers.ITResumeManagers;
using ITResume.Client.Managers.ITResumeManagers.UniqueNameManagers;
using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Services.ITResumeServices.UniqueNameServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Client.Managers.ITResumeManagers.UniqueNameServices;

public class TechnologyManager : UniqueNameManager<Technology>, ITechnologyService
{
    public TechnologyManager(HttpClient httpClient) : base(httpClient, "technologies") { }
}
