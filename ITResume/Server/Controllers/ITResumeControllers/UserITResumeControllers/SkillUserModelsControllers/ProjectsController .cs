using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;
using ITResume.Shared.Models.ViewModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UserITResumeControllers.SkillUserModelsControllers;

public class ProjectsController : SkillUserModelsController<Project>
{
    public ProjectsController(IProjectService service, IUserService userService) : base(service, userService) { }
}
