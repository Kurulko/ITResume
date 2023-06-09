using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.EntityFrameworkCore;
using ITResume.Client.Managers.ITResumeManagers;
using ITResume.Shared.Models.Database;

namespace ITResume.Client.Managers.ITResumeServices;

public class EducationManager : ITResumeDbModelManager<Education>, IEducationService
{
    public EducationManager(HttpClient httpClient) : base(httpClient, "educations") { }
}