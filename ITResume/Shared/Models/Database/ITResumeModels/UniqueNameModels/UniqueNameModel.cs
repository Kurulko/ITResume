using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;

[Index(nameof(Name), IsUnique = true)]
public abstract class UniqueNameModel : ITResumeDbModel
{
    [Required(ErrorMessage = "Enter {0}!")]
    public string Name { get; set; } = null!;
}
