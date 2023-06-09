using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.Database;

public class Project : UserITResumeDbModel
{
    [Required(ErrorMessage = "Enter project's name!")]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Url]
    public string? Github { get; set; }

    [Url]
    public string? Link { get; set; }

    [Display(Name = "Work Example")]
    public string? WorkExample { get; set; }

    [Display(Name = "Start")]
    public DateTime StartDoing { get; set; }

    [Display(Name = "End")]
    public DateTime? FinishDoing { get; set; }


    public string? UserId { get; set; }
    public IEnumerable<Technology>? Technologies { get; set; }
    public IEnumerable<ProgrammingLanguage>? ProgrammingLanguages { get; set; }
}
