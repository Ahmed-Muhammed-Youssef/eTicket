using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Interfaces;

namespace mvc.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            this._movieService = movieService;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllAsync(n => n.Cinema);
            return View(movies);
        }
    }
}
