using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NewlyReused.Models;

namespace NewlyReused.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _env;

    public HomeController(ApplicationDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }



    public IActionResult Index()
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
