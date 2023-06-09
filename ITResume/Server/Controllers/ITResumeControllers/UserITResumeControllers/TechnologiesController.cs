using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UserITResumeControllers;

public class TechnologiesController : UserITResumeDbModelsController<Technology>
{
    public TechnologiesController(ITechnologyService service, IUserService userService) : base(service, userService) { }

    protected override Technology? ReturnModelWithoutCycles(Technology? model)
    {
        if (model is not null && model.User is not null)
        {
            model.User!.Technologies = null;
            return model;
        }
        return model;
    }
}
