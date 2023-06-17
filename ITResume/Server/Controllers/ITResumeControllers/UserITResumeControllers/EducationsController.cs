using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UserITResumeControllers;

public class EducationsController : UserITResumeDbModelsController<Education>
{
    public EducationsController(IEducationService service, IUserService userService) : base(service, userService) { }
}
