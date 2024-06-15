using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewlyReused.Models;
using System.Text.Json;
using System.IO;

namespace NewlyReused.Controllers
{
    public class PlacesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;

        public PlacesController(ApplicationDbContext context)
        {
            _context = context;
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
    {
        {
            string apiUrl = "https://services6.arcgis.com/fUWVlHWZNxUvTUh8/arcgis/rest/services/DrinkingFountains/FeatureServer/0/query?outFields=*&where=1%3D1&f=geojson";
            try
            {
                // Send GET request to the API
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                //Console.WriteLine(response.Content);
                response.EnsureSuccessStatusCode();
                

                // Read the API response as JSON string
                string apiResponse = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(apiResponse);

                // TODO: Deserialize the JSON response to your C# models
                // You'll need to define appropriate models to match the API response structure
                PlaceResponse places = JsonSerializer.Deserialize<PlaceResponse>(apiResponse); // Place - ApiResponse
                //Console.WriteLine(places.Type);
                List<Feature> intermStops = new List<Feature>();
                
                int index = 0;
                foreach (var item in places.Features)
                {
                    index = index + 1;
                    FeatureProperties properties = item.Properties;
                    //Console.WriteLine($"Properties: {JsonSerializer.Serialize(properties)}");
                    intermStops.Add(new Feature(item.Type, item.Id, item.Geometry.Coordinates[0], item.Geometry.Coordinates[1], index, properties));
                }

                PlacesViewModel viewModel = new PlacesViewModel
                {
                    Stops = intermStops
                };
    
                return View(viewModel);
            }
            catch (Exception ex)
            {
                // Handle other types of exceptions
                ViewData["ErrorMessage"] = "An unexpected error occurred. Please try again later.";
            }

            // Return a default view if no data or an error occurred
            return View();
        }
    }

        public async Task<IActionResult> Map()
        {
            var places = await _context.Places.ToListAsync();
            return View(places);
        }

        public async Task<IActionResult> Details(int id)
        {
            var place = await _context.Places.FindAsync(id);
            if (place == null)
            {
                return NotFound();
            }
            return View(place);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int placeId, string comment)
        {
            var userComment = new UserComment
            {
                PlaceId = placeId,
                Comment = comment,
                Date = DateTime.Now
            };
            _context.UserComments.Add(userComment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = placeId });
        }
    

    }
}