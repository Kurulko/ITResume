using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITResume.Shared.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using ITResume.Shared.Models.Database;

namespace ITResume.Client.Managers;

public class RoleManager : DbModelManager<Role, string>, IRoleService
{
    public RoleManager(HttpClient httpClient) : base(httpClient, "roles") { }
}
