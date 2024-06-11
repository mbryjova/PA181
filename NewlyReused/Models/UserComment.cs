using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewlyReused.Models
{
    public class UserComment
    {
    public int Id { get; set; }
    public int PlaceId { get; set; }
    public string Comment { get; set; }
    public DateTime Date { get; set; }
    
    public Place Place { get; set; }
    }
}