using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.Account;

public class CurrentUser
{
    public bool IsAuthenticated { get; set; }
    public string UserName { get; set; } = null!;
    public IEnumerable<KeyValuePair<string, string>> Claims { get; set; } = null!;
}