using ITResume.Shared.Enums;
using ITResume.Shared.Models.Database.ITResumeModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ITResume.Shared.Models.Database.ITResumeModels.UserModels;

public class ForeignLanguage : UserITResumeDbModel
{
    [Display(Name = "Level")]
    public LanguageLevel LanguageLevel { get; set; }

    public string? UserId { get; set; }
    public long HumanLanguageId { get; set; }
    public HumanLanguage? HumanLanguage { get; set; }
}
