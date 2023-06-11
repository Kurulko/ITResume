using ITResume.Shared;
using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers;

[Authorize(Roles = Roles.Admin)]
public class AdminDbModelsController<TModel, TKey> : DbModelsController<TModel, TKey> where TModel : IDbModel
{
    public AdminDbModelsController(IDbModelService<TModel, TKey> service) : base(service) { }
}
