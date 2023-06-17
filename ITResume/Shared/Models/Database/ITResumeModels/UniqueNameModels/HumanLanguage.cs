using ITResume.Shared.Enums;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;

public class HumanLanguage : UniqueNameModel
{
    public IEnumerable<ForeignLanguage>? ForeignLanguages { get; set; }
}
