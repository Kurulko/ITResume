using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UserITResumeControllers;

public class ProjectsController : UserITResumeDbModelsController<Project>
{
    public ProjectsController(IProjectService service, IUserService userService) : base(service, userService) { }

    protected override Project? ReturnModelWithoutCycles(Project? model)
    {
        if (model is not null && model.User is not null)
        {
            model.User!.Projects = null;
            return model;
        }
        return model;
    }
}
