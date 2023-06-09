using Newtonsoft.Json;

namespace ITResume.Client.Parser.Linkedin.Models;

public class UserContactInfo
{
    [JsonProperty("emailAddress")]
    public string? EmailAddress { get; set; }

    [JsonProperty("phoneNumbers")]
    public List<PhoneNumber>? PhoneNumbers { get; set; }
}
