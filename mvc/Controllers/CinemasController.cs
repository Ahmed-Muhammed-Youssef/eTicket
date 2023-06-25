using Microsoft.AspNetCore.Mvc;
using mvc.Interfaces;

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
    }
}
