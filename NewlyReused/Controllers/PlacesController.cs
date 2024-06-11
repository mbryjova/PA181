using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewlyReused.Models;

namespace NewlyReused.Controllers
{
    public class PlacesController: Controller
    {
        private readonly ApplicationDbContext _context;

        public PlacesController(ApplicationDbContext context)
        {
            _context = context;
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

        [HttpPost]
        public async Task<IActionResult> MarkVisited(int placeId)
        {
            var place = await _context.Places.FindAsync(placeId);
            if (place != null)
            {
                place.Visited = true;
                _context.Update(place);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Details", new { id = placeId });
        }
    }
}