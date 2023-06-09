using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.Database;

public class Country : ITResumeDbModel
{
    [Required(ErrorMessage = "Enter country's name!")]
    public string Name { get; set; } = null!;

    public IEnumerable<Education>? Educations { get; set; }
    public IEnumerable<Company>? Companies { get; set; }
    public IEnumerable<User>? Users { get; set; }
}
