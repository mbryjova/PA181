using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewlyReused.Models
{
    public class Geometry
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        public double[] Coordinates { get; set; }
        //public Coordinates Coordinates { get; set; }
        public Geometry()
		{
            Coordinates = new double[2]; // Assuming it's always an array with 2 elements
		} 
    }
}