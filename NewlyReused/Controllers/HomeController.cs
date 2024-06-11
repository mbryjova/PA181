using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NewlyReused.Models;

namespace NewlyReused.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
}
