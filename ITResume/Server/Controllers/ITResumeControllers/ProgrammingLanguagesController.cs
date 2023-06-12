using ITResume.Shared.Models.Database.ITResumeModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers;

[Route("api/programming-languages")]
public class ProgrammingLanguagesController : AdminITResumeDbModelsController<ProgrammingLanguage>
{
    public ProgrammingLanguagesController(IProgrammingLanguageService service) : base(service) { }
}
