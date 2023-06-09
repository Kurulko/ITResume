using Newtonsoft.Json;

namespace ITResume.Client.Parser.Linkedin.Models;

public class UserSkill
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("level")]
    public string? Level { get; set; }
}
