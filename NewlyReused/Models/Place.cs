using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using NewlyReused.Models;

namespace NewlyReused.Models
{
    public class Place
    {
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; }
    
    }
}