using ITResume.Shared;
using ITResume.Shared.Models.Database.ITResumeModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers;

[Authorize(Roles = Roles.Admin)]
public class AdminITResumeDbModelsController<T> : ITResumeDbModelsController<T> where T : ITResumeDbModel
{
    public AdminITResumeDbModelsController(IDbModelService<T, long> service) : base(service) { }

    [AllowAnonymous]
    public override Task<IEnumerable<T>> GetModelsAsync()
        => base.GetModelsAsync();

    [AllowAnonymous]
    public override Task<T?> GetModelByIdAsync(long key)
        => base.GetModelByIdAsync(key);
}
