using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewlyReused.Models
{
    public class Place
    {
        public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool Visited { get; set; }
    public ICollection<UserComment> UserComments { get; set; }
    }
}