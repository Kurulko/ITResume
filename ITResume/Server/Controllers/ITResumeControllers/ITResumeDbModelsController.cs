using ITResume.Shared;
using ITResume.Shared.Models.Database.ITResumeModels;
using ITResume.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers;

public abstract class ITResumeDbModelsController<T> : DbModelsController<T, long> where T : ITResumeDbModel
{
    public ITResumeDbModelsController(IDbModelService<T, long> service) : base(service) { }
}
