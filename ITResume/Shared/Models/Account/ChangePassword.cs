using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ITResume.Shared.Models.Account;

public class ChangePassword
{
    [Display(Name = "Old password")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least {1} characters long")]
    public string? OldPassword { get; set; } = null!;

    [Display(Name = "New password")]
    [Required(ErrorMessage = "Enter new password")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least {1} characters long")]
    public string NewPassword { get; set; } = null!;

    [Display(Name = "Repeat new password")]
    [Required(ErrorMessage = "Repeat new password")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least {1} characters long")]
    [Compare("NewPassword", ErrorMessage = "Passwords don't match")]
    public string ConfirmNewPassword { get; set; } = null!;
}