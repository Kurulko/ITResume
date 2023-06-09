using ITResume.Shared.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Services.Account;

public interface IAuthService
{
    Task LoginUserAsync(LoginModel model);
    Task RegisterUserAsync(RegisterModel model);
    Task LogoutUserAsync();
}