using ITResume.Shared;
using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers;

public class RolesController : AdminDbModelsController<Role, string>
{
    public RolesController(IRoleService service) : base(service) { }
}
