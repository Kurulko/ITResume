using ITResume.Shared;
using Microsoft.AspNetCore.Identity;
using ITResume.Shared.Models.Database;

namespace ITResume.Server.Initializers;

public class UsersInitializer
{
    public static async Task AdminInitializeAsync(UserManager<User> userManager, string name, string password)
    {
        if (await userManager.FindByNameAsync(name) is null)
        {
            User admin = new() { UserName = name, Registered = DateTime.Now };
            IdentityResult result = await userManager.CreateAsync(admin, password);
            if (result.Succeeded)
                await userManager.AddToRoleAsync(admin, Roles.Admin);
        }
    }
}