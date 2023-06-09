using ITResume.Client.Managers.ITResumeManagers;
using ITResume.Shared.Models.Database;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Client.Managers.ITResumeServices;

public class TechnologyManager : ITResumeDbModelManager<Technology>, ITechnologyService
{
    public TechnologyManager(HttpClient httpClient) : base(httpClient, "technologies") { }
}
