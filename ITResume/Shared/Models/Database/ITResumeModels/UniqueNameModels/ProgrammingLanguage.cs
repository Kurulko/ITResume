using ITResume.Shared.Enums;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;

public class ProgrammingLanguage : UniqueNameModel
{
    public IEnumerable<User>? Users { get; set; }
    public IEnumerable<Project>? Projects { get; set; }
    public IEnumerable<Employee>? Employees { get; set; }
}
