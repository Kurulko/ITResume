using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;

namespace ITResume.Shared.Models.Database.ITResumeModels.UserModels;

public class Contact : UserITResumeDbModel
{
    public string? City { get; set; }
    public string? Address { get; set; }

    [Phone]
    public string? MobilePhone { get; set; }

    public string? Github { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    public string? Telegram { get; set; }

    [Url]
    public string? LinkedId { get; set; }

    [Url]
    public string? Stackoverflow { get; set; }

    [Url]
    public string? Habr { get; set; }

    public long? CountryId { get; set; }
    public Country? Country { get; set; }
}
