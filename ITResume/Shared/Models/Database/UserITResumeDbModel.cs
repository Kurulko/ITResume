using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.Database;

public abstract class UserITResumeDbModel : ITResumeDbModel
{
    public User? User { get; set; }
}
