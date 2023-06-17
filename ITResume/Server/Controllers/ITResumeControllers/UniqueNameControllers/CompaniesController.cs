using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UniqueNameServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UniqueNameControllers;

public class CompaniesController : UniqueNameController<Company>
{
    public CompaniesController(ICompanyService service) : base(service) { }

    [AllowAnonymous]
    public override Task<Company> AddModelAsync(Company model)
        => base.AddModelAsync(model);
}
