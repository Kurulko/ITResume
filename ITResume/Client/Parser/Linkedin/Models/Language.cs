﻿using Newtonsoft.Json;

namespace ITResume.Client.Parser.Linkedin.Models;

public class Language
{
    [JsonProperty("name")]
    public string? Name { get; set; }
}
