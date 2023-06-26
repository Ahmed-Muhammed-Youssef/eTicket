using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Data.ViewModels;
using mvc.Interfaces;
using mvc.Models;
using mvc.Services;

namespace mvc.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICinemaService _cinemaService;
        private readonly IActorService _actorService;
        private readonly IProducerService _producerService;

        public MoviesController(IMovieService movieService, ICinemaService cinemaService, IActorService actorService, IProducerService producerService)
        {
            _movieService = movieService;
            _cinemaService = cinemaService;
            _actorService = actorService;
            _producerService = producerService;
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

        // GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var actors = _actorService.GetAllAsync();
            var producers = _producerService.GetAllAsync();
            var cinemas = _cinemaService.GetAllAsync();
            await Task.WhenAll(actors, producers, cinemas);
            ViewBag.Actors = new SelectList(actors.Result, "Id", "FullName");
            ViewBag.Producers = new SelectList(producers.Result, "Id", "FullName");
            ViewBag.Cinemas = new SelectList(cinemas.Result, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieVM movieVm)
        {
            var actors = _actorService.GetAllAsync();
            var producers = _producerService.GetAllAsync();
            var cinemas = _cinemaService.GetAllAsync();
            await Task.WhenAll(actors, producers, cinemas);
            ViewBag.Actors = new SelectList(actors.Result, "Id", "FullName");
            ViewBag.Producers = new SelectList(producers.Result, "Id", "FullName");
            ViewBag.Cinemas = new SelectList(cinemas.Result, "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View(movieVm);
            }

            var movie = await _movieService.AddMovieVMAsync(movieVm);
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Movies/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieService
                .GetByIdWithInclusionAsync(id);
            if (movie == null)
            {
                return View("NotFound");
            }
            
            var actors = _actorService.GetAllAsync();
            var producers = _producerService.GetAllAsync();
            var cinemas = _cinemaService.GetAllAsync();

            var movieVm = new MovieVM()
            {
                Id = movie!.Id,
                Name = movie.Name,
                Price = movie.Price,
                Description = movie.Description,
                StratDate = movie.StratDate,
                EndDate = movie.EndDate,
                MovieCategory = movie.MovieCategory,
                ImageUrl = movie.ImageUrl,
                ProducerId = movie.ProducerId,
                CinemaId = movie.CinemaId,
                ActorIds = movie.ActorsMovies!.Select(am => am.ActorId)
            };
            await Task.WhenAll(actors, producers, cinemas);
            ViewBag.Actors = new SelectList(actors.Result, "Id", "FullName");
            ViewBag.Producers = new SelectList(producers.Result, "Id", "FullName");
            ViewBag.Cinemas = new SelectList(cinemas.Result, "Id", "Name");

            return View(movieVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MovieVM movieVm)
        {
            var actors = _actorService.GetAllAsync();
            var producers = _producerService.GetAllAsync();
            var cinemas = _cinemaService.GetAllAsync();
            await Task.WhenAll(actors, producers, cinemas);
            ViewBag.Actors = new SelectList(actors.Result, "Id", "FullName");
            ViewBag.Producers = new SelectList(producers.Result, "Id", "FullName");
            ViewBag.Cinemas = new SelectList(cinemas.Result, "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View(movieVm);
            }

            var movie = await _movieService.UpdateMovieVMAsync(movieVm);

            return RedirectToAction(nameof(Index));
        }
    }
}
