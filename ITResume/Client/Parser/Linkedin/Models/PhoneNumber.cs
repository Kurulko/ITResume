using Newtonsoft.Json;

namespace ITResume.Client.Parser.Linkedin.Models;

public class PhoneNumber
{
    [JsonProperty("number")]
    public string? Number { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }
}
