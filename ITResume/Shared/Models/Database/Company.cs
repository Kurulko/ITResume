using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.Database;

public class Company : ITResumeDbModel
{
    [Required(ErrorMessage = "Enter company's name!")]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Display(Name = "Start")]
    public DateTime StartWorking { get; set; }

    [Display(Name = "End")]
    public DateTime? FinishWorking { get; set; }

    public long CountryId { get; set; }
    public Country? Country { get; set; }
    public IEnumerable<Employee>? Employees { get; set; }
    public IEnumerable<ProgrammingLanguage>? ProgrammingLanuages { get; set; }
    public IEnumerable<Technology>? Technologies { get; set; }
}
