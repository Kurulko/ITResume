using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UniqueNameServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UniqueNameControllers;

public class TechnologiesController : UniqueNameController<Technology>
{
    public TechnologiesController(ITechnologyService service) : base(service) { }

}
