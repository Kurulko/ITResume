using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.Database;

public class Employee : UserITResumeDbModel
{
    [Required(ErrorMessage = "Enter the post!")]
    public string Post { get; set; } = null!;

    [Display(Name = "Start")]
    public DateTime StartWorking { get; set; }

    [Display(Name = "End")]
    public DateTime? FinishWorking { get; set; }

    public string? Description { get; set; }
    public decimal? Salary { get; set; }

    public long CompanyId { get; set; }
    public Company? Company { get; set; }
    public string? UserId { get; set; }

    public IEnumerable<Technology>? Technologies { get; set; }
    public IEnumerable<ProgrammingLanguage>? ProgrammingLanguages { get; set; }
}
