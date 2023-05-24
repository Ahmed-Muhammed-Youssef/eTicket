using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;

namespace mvc.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movie
                .Include(m => m.Producer)
                .Include(m => m.Cinema)
                .ToListAsync();
            return View(movies);
        }
    }
}
