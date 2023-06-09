using ITResume.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Models.Database;

public class User : IdentityUser, IDbModel
{
    [Display(Name = "First name")]
    public string? FirstName { get; set; }

    [Display(Name = "Last name")]
    public string? LastName { get; set; }

    [Display(Name = "Father name")]
    public string? FatherName { get; set; }

    public DateTime Birthday { get; set; }
    public DateTime Registered { get; set; }
    public string? UsedUserId { get; set; }


    public long? UserDetailsId { get; set; }
    public UserDetails? UserDetails { get; set; }
    public long? ContactId { get; set; }
    public Contact? Contact { get; set; }
    public IEnumerable<Project>? Projects { get; set; }
    public IEnumerable<Employee>? Employees { get; set; }
    public IEnumerable<Achievement>? Achievements { get; set; }
    public IEnumerable<Technology>? Technologies { get; set; }
    public IEnumerable<Education>? Educations { get; set; }
    public IEnumerable<ForeignLanguage>? ForeignLanguages { get; set; }
    public IEnumerable<ProgrammingLanguage>? ProgrammingLanguages { get; set; }
}
