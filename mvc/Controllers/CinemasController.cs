using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;

namespace mvc.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext _context;

        public CinemasController(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var cinemas = await _context.Cinema.ToListAsync();
            return View(cinemas);
        }
    }
}
