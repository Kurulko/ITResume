using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.Database.ITResumeModels.UserModels;

public class Achievement : UserITResumeDbModel
{
    [Required(ErrorMessage = "Enter achievement's name!")]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Url]
    public string? Link { get; set; }

    public DateTime When { get; set; }

    public string? UserId { get; set; }
}
