using ITResume.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.Database;

public class ProgrammingLanguage : ITResumeDbModel
{
    [Required(ErrorMessage = "Enter programming language's name!")]
    public string Name { get; set; } = null!;

    public IEnumerable<User>? Users { get; set; }
    public IEnumerable<Project>? Projects { get; set; }
    public IEnumerable<Employee>? Employees { get; set; }
}
