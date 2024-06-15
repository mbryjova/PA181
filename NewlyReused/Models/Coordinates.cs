using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewlyReused.Models
{
    public class Coordinates
    {
        [JsonPropertyName("x")]
        public double X { get; set; }

        [JsonPropertyName("y")]
        public double Y { get; set; }
        public Coordinates()
		{
		}
	}
}