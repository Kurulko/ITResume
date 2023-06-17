using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UniqueNameServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UniqueNameControllers;

public abstract class UniqueNameController<T> : AdminITResumeDbModelsController<T> where T : UniqueNameModel
{
    public UniqueNameController(IUniqueNameService<T> service) : base(service) { }

    IUniqueNameService<T> uniqueNameService => (service as IUniqueNameService<T>)!;

    [AllowAnonymous]
    [HttpGet("name/{uniqueName}")]
    public virtual async Task<T?> GetModelByUniqueNameAsync(string uniqueName)
        => await uniqueNameService.GetModelByUniqueNameAsync(uniqueName);
}
