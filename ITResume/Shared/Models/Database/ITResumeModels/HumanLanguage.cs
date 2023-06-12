using ITResume.Shared.Enums;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.Database.ITResumeModels;

public class HumanLanguage : ITResumeDbModel
{
    [Required(ErrorMessage = "Enter language's name!")]
    public string Name { get; set; } = null!;

    public IEnumerable<ForeignLanguage>? ForeignLanguages { get; set; }
}
