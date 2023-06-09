using ITResume.Shared;
using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers;

public class RolesController : DbModelsController<Role, string>
{
    public RolesController(IRoleService service) : base(service) { }

    [Authorize(Roles = Roles.Admin)]
    public override async Task<IEnumerable<Role>> GetModelsAsync()
        => await base.GetModelsAsync();

    [Authorize(Roles = Roles.Admin)]
    public override async Task<Role?> GetModelByIdAsync(string key)
        => await base.GetModelByIdAsync(key);
}
