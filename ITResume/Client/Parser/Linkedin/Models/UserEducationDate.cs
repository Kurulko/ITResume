using Newtonsoft.Json;

namespace ITResume.Client.Parser.Linkedin.Models;

public class UserEducationDate
{
    [JsonProperty("year")]
    public int Year { get; set; }
}
