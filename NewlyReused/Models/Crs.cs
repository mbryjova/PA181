using System;
using System.Text.Json.Serialization;

namespace NewlyReused.Models
{
	public class Crs
	{
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("properties")]
         public CrsProperties Properties { get; set; }

        public Crs()
		{
		}
	}
}