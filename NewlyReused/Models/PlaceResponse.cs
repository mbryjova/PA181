using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewlyReused.Models
{
    public class PlaceResponse
    {
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; }
    
    }
}