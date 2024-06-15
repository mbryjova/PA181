using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NewlyReused.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace NewlyReused.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _env;

    private readonly HttpClient _httpClient;


    public HomeController(ApplicationDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
        _httpClient = new HttpClient();
    }



    public async Task<IActionResult> Index()
    {
        {
            return View();
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> Index2()
    {
        // Path to your GeoJSON file
        var filePath = Path.Combine(_env.WebRootPath, "data", "DrinkingFountains.geojson");

        // Read the content of the file
        string fileContent;
        using (var reader = new StreamReader(filePath))
        {
            fileContent = await reader.ReadToEndAsync();
        }

        // Pass the file content to the view
        ViewData["GeoJsonContent"] = fileContent;

        return View();
    }
}
