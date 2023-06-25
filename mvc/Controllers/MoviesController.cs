using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Interfaces;
using mvc.Services;

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

        // GET: Movies/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService
                .GetByIdWithInclusionAsync(id);
            if (movie != null)
            {
                return View(movie);
            }
            return View("NotFound");
        }
    }
}
