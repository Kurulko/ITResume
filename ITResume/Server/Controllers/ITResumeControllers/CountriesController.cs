using ITResume.Shared.Models.Database.ITResumeModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers;

public class CountriesController : AdminITResumeDbModelsController<Country>
{
    public CountriesController(ICountryService service) : base(service) { }
}
