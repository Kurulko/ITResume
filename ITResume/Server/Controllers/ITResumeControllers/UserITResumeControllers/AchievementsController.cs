using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UserITResumeControllers;

public class AchievementsController : UserITResumeDbModelsController<Achievement>
{
    public AchievementsController(IAchievementService service, IUserService userService) : base(service, userService) { }

    protected override Achievement? ReturnModelWithoutCycles(Achievement? model)
    {
        if (model is not null && model.User is not null)
        {
            model.User!.Achievements = null;
            return model;
        }
        return model;
    }
}
