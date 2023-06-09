using ITResume.Shared;
using ITResume.Shared.Models.Database;
using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;

namespace ITResume.Server.Initializers;

public class RolesInitializer
{
    public static async Task InitializeAsync(RoleManager<Role> roleManager)
    {
        string[] rolesStr = { Roles.Admin, Roles.User };
        foreach (string roleStr in rolesStr)
        {
            Role? role =  await roleManager.FindByNameAsync(roleStr);
            if (role is null)
                await roleManager.CreateAsync(new Role() { Name = roleStr });
        }
    }
}