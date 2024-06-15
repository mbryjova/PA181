using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewlyReused.Models
{
    public class FeatureProperties
    {
        [JsonPropertyName("OBJECTID")]
        public int ObjectId { get; set; }

        [JsonPropertyName("TITLE")]
        public string Title { get; set; }

        [JsonPropertyName("DESCRIPTION")]
        public string Description { get; set; }

        [JsonPropertyName("IMAGE_URL")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("GlobalID")]
        public string GlobalId { get; set; }

        [JsonPropertyName("PARO")]
        public object Paro { get; set; }
    }
}