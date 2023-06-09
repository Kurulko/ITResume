using Newtonsoft.Json;

namespace ITResume.Client.Parser.Linkedin.Models;

public class UserProfile
{
    [JsonProperty("contactInfo")]
    public UserContactInfo? ContactInfo { get; set; }

    [JsonProperty("educations")]
    public List<UserEducation>? Educations { get; set; }

    [JsonProperty("languages")]
    public List<UserLanguage>? Languages { get; set; }

    [JsonProperty("projects")]
    public List<UserProject>? Projects { get; set; }

    [JsonProperty("skills")]
    public List<UserSkill>? Skills { get; set; }
}