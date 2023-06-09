using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UserITResumeControllers;

public class EducationsController : UserITResumeDbModelsController<Education>
{
    public EducationsController(IEducationService service, IUserService userService) : base(service, userService) { }

    protected override Education? ReturnModelWithoutCycles(Education? model)
    {
        if (model is not null && model.User is not null)
        {
            model.User!.Educations = null;
            return model;
        }
        return model;
    }
}
