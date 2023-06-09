using ITResume.Shared.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Services;

public interface IRoleService : IDbModelService<Role, string> { }
