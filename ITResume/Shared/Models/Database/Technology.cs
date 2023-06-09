using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.Database;

public class Technology : UserITResumeDbModel
{
    [Required(ErrorMessage ="Enter techonoly's name!")]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    [Url]
    public string? Link { get; set; }

    public string? UserId { get; set; }
    public IEnumerable<Project>? Projects { get; set; }
    public IEnumerable<Employee>? Employees { get; set; }
}
