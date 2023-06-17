using ITResume.Shared.Enums;
using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ITResume.Shared.Models.Database.ITResumeModels.UserModels;

public class Education : UserITResumeDbModel
{
    [Required(ErrorMessage = "Enter specialty!")]
    public string Specialty { get; set; } = null!;

    public string? Faculty { get; set; }


    [Required(ErrorMessage = "Enter university!")]
    public string University { get; set; } = null!;

    [Display(Name = "Institution")]
    public TypeOfEducation TypeOfEducation { get; set; }

    [Display(Name = "Degree")]
    public DegreeOfEducation DegreeOfEducation { get; set; }

    [Display(Name = "Start")]
    public DateTime StartEducation { get; set; }

    [Display(Name = "End")]
    public DateTime? FinishEducation { get; set; }

    public string? UserId { get; set; }
    public long? CountryId { get; set; }
    public Country? Country { get; set; }
}
