using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ITResume.Shared.Models.Database;

public class UserDetails : UserITResumeDbModel
{
    [Display(Name = "Is public profile?")]
    public bool IsPublicProfile { get; set; }
}
