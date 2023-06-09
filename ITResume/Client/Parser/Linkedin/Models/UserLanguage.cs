using Newtonsoft.Json;

namespace ITResume.Client.Parser.Linkedin.Models;

public class UserLanguage
{
    [JsonProperty("language")]
    public Language? Language { get; set; }
}
