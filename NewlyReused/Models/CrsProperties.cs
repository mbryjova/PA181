using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewlyReused.Models
{
    public class CrsProperties
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}