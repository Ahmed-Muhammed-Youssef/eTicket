using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;

namespace mvc.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;

        public ActorsController(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var actors = await _context.Actor.ToListAsync();
            return View(actors);
        }
    }
}
