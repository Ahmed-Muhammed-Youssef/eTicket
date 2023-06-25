using Microsoft.AspNetCore.Mvc;
using mvc.Interfaces;
using mvc.Services;

namespace mvc.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemasController(ICinemaService cinemaService)
        {
            this._cinemaService = cinemaService;
        }
        public async Task<IActionResult> Index()
        {
            var cinemas = await _cinemaService.GetAllAsync();
            return View(cinemas);
        }

        // GET: Cinemas/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
            if (cinema != null)
            {
                return View(cinema);
            }
            return View("NotFound");
        }
    }
}
