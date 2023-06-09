﻿using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers;

[Route("api/programming-languages")]
public class ProgrammingLanguagesController : ITResumeDbModelsController<ProgrammingLanguage>
{
    public ProgrammingLanguagesController(IProgrammingLanguageService service) : base(service) { }
}