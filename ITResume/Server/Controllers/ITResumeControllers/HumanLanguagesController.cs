using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers;

[Route("api/human-languages")]
public class HumanLanguagesController : ITResumeDbModelsController<HumanLanguage>
{
    public HumanLanguagesController(IHumanLanguageService service) : base(service) { }
}
