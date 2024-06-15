using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewlyReused.Models
{
    public class Feature
    {

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("geometry")]
    public Geometry Geometry { get; set; }

    [JsonPropertyName("properties")]
    public FeatureProperties Properties { get; set; }
    
    public int Indx;
    public Feature()
		{
            Geometry = new Geometry
            {
            Coordinates = new double[2] // Assuming it's always an array with 2 elements
            };
		}
    public Feature(string type, int id, double x, double y, int index, FeatureProperties properties)
		{
            Geometry = new Geometry
            {
            Coordinates = new double[2] 
            };

			Type = type;
			Id = id;
			Geometry.Coordinates[0] = x;
			Geometry.Coordinates[1] = y;
			Indx = index;
            Properties = properties;

		}
	}
}