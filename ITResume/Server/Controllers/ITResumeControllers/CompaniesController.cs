using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers;

public class CompaniesController : AdminITResumeDbModelsController<Company>
{
    public CompaniesController(ICompanyService service) : base(service) { }
}
