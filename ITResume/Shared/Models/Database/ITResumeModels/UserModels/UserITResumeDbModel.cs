using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITResume.Shared.Models.Database.ITResumeModels;

namespace ITResume.Shared.Models.Database.ITResumeModels.UserModels;

public abstract class UserITResumeDbModel : ITResumeDbModel
{
    public User? User { get; set; }
}
