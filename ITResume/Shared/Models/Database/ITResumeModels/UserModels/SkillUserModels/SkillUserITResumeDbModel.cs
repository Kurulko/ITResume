using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;

namespace ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;

public abstract class SkillUserITResumeDbModel : UserITResumeDbModel
{
    public IEnumerable<Technology>? Technologies { get; set; }
    public IEnumerable<ProgrammingLanguage>? ProgrammingLanguages { get; set; }
}
