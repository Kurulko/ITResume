using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UniqueNameServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UniqueNameControllers;

[Route("api/human-languages")]
public class HumanLanguagesController : UniqueNameController<HumanLanguage>
{
    public HumanLanguagesController(IHumanLanguageService service) : base(service) { }
}
