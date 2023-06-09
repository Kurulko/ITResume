using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UserITResumeControllers;

[Route("api/foreign-languages")]
public class ForeignLanguagesController : UserITResumeDbModelsController<ForeignLanguage>
{
    public ForeignLanguagesController(IForeignLanguageService service, IUserService userService) : base(service, userService) { }

    protected override ForeignLanguage? ReturnModelWithoutCycles(ForeignLanguage? model)
    {
        if (model is not null && model.User is not null)
        {
            model.User!.ForeignLanguages = null;
            return model;
        }
        return model;
    }
}
