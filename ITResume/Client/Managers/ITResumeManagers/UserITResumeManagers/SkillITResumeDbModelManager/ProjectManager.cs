using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ITResume.Shared.Services.ITResumeServices.UserServices;
using System.Net.Http.Json;
using ITResume.Shared.Models.ViewModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;

namespace ITResume.Client.Managers.ITResumeManagers.UserITResumeManagers.SkillITResumeDbModelManager;

public class ProjectManager : SkillITResumeDbModelManager<Project>, IProjectService
{
    public ProjectManager(HttpClient httpClient) : base(httpClient, "projects") { }
}