using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UniqueNameServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UniqueNameControllers;

[Route("api/programming-languages")]
public class ProgrammingLanguagesController : UniqueNameController<ProgrammingLanguage>
{
    public ProgrammingLanguagesController(IProgrammingLanguageService service) : base(service) { }
}
