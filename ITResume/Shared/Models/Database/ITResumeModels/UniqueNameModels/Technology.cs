using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;

namespace ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;

public class Technology : UniqueNameModel
{
    public string? Description { get; set; }

    [Url]
    public string? Link { get; set; }

    public IEnumerable<User>? Users { get; set; }
    public IEnumerable<Project>? Projects { get; set; }
    public IEnumerable<Employee>? Employees { get; set; }
}
