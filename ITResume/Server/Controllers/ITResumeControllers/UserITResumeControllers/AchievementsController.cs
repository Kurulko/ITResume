using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UserITResumeControllers;

public class AchievementsController : UserITResumeDbModelsController<Achievement>
{
    public AchievementsController(IAchievementService service, IUserService userService) : base(service, userService) { }
}
