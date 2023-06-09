using Newtonsoft.Json;

namespace ITResume.Client.Parser.Linkedin.Models;

public class UserEducation
{
    [JsonProperty("schoolName")]
    public string? SchoolName { get; set; }

    [JsonProperty("degree")]
    public string? Degree { get; set; }

    [JsonProperty("fieldOfStudy")]
    public string? FieldOfStudy { get; set; }

    [JsonProperty("startDate")]
    public UserEducationDate? StartDate { get; set; }

    [JsonProperty("endDate")]
    public UserEducationDate? EndDate { get; set; }
}
