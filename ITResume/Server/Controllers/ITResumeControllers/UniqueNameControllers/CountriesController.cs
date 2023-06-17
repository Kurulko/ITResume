using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UniqueNameServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UniqueNameControllers;

public class CountriesController : UniqueNameController<Country>
{
    public CountriesController(ICountryService service) : base(service) { }
}
