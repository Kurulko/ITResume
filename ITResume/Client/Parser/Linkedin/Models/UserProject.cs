using Newtonsoft.Json;

namespace ITResume.Client.Parser.Linkedin.Models;

public class UserProject
{
    [JsonProperty("title")]
    public string? Title { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }
}
