using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;

namespace mvc.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;

        public ProducersController(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var producers = await _context.Producer.ToListAsync();
            return View(producers);
        }
    }
}
