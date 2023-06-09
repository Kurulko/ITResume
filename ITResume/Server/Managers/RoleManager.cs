using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITResume.Shared.Services;
using ITResume.Server.Database;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using ITResume.Shared.Models.Database;

namespace ITResume.Server.Managers;

public class RoleManager : IRoleService
{
    readonly RoleManager<Role> roleManager;
    readonly ITResumeContext db;
    public RoleManager(RoleManager<Role> roleManager, ITResumeContext db)
        => (this.roleManager, this.db) = (roleManager, db);

    public async Task AddModelAsync(Role model)
    {
        await db.Roles.AddAsync(model);
        db.SaveChanges();
    }

    public async Task DeleteModelAsync(string key)
    {
        Role? role = await GetModelByIdAsync(key);
        if (role is not null)
            await roleManager.DeleteAsync(role);
    }

    public async Task<IEnumerable<Role>> GetAllModelsAsync()
        => await db.Roles.ToListAsync();

    public async Task<Role?> GetModelByIdAsync(string key)
        => await db.Roles.FirstOrDefaultAsync(u => u.Id == key);

    public async Task UpdateModelAsync(Role model)
        => await roleManager.UpdateAsync(model);
}
