using ITResume.Server.Initializers.ITResumeInitializers;
using ITResume.Shared;
using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ITResume.Server.Controllers;

public abstract class DbModelsController<T, K> : ApiController where T : IDbModel
{
    protected readonly IDbModelService<T, K> service;
    public DbModelsController(IDbModelService<T, K> service)
        => this.service = service;

    [HttpGet]
    public virtual async Task<IEnumerable<T>> GetModelsAsync()
        => await service.GetAllModelsAsync();

    [HttpGet("{key}")]
    public virtual async Task<T?> GetModelByIdAsync(K key)
        => await service.GetModelByIdAsync(key);

    [HttpPost]
    public virtual async Task<T> AddModelAsync(T model)
        => await service.AddModelAsync(model);

    [HttpPut]
    public virtual async Task<IActionResult> UpdateModelAsync(T model)
        => await ReturnOkIfEverithingIsGood(async () => await service.UpdateModelAsync(model));

    [HttpDelete("{key}")]
    public virtual async Task<IActionResult> DeleteModelAsync(K key)
        => await ReturnOkIfEverithingIsGood(async () => await service.DeleteModelAsync(key));
}