﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvc.Data.Static;
using mvc.Data.ViewModels;
using mvc.Interfaces;

namespace mvc.Controllers
{
    [Authorize(Roles = UserRolesValues.Admin)]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICinemaService _cinemaService;
        private readonly IActorService _actorService;
        private readonly IDirectorService _producerService;

        public MoviesController(IMovieService movieService, ICinemaService cinemaService, IActorService actorService, IDirectorService producerService)
        {
            _movieService = movieService;
            _cinemaService = cinemaService;
            _actorService = actorService;
            _producerService = producerService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllAsync(trackChanges: false, n => n.Cinema, m => m.Image);
            return View(movies);
        }
        [AllowAnonymous]
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
            return View(new MovieVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieVM movieVm)
        {
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
                Image = movie.Image,
                Name = movie.Name,
                Price = movie.Price,
                Description = movie.Description,
                StratDate = movie.StratDate,
                EndDate = movie.EndDate,
                MovieCategory = movie.MovieCategory,
                DirectorId = movie.DirectorId,
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
            if (!ModelState.IsValid)
            {
                return View(movieVm);
            }

            var movie = await _movieService.UpdateMovieVMAsync(movieVm);

            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var movies = await _movieService.GetAllAsync(trackChanges: false, n => n.Image);
            if(string.IsNullOrEmpty(searchString))
            {
                return View("Index", movies);
            }
            searchString = searchString.ToLower();
            return View("Index", movies.Where(m => m.Name!.ToLower().Contains(searchString) || m.Description!.ToLower().Contains(searchString)));
        }

        // GET: Movies/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieService.GetByIdAsync(id, trackChanges: false, m => m.Image);
            if (movie == null)
            {
                return View("NotFound");
            }
            return View(movie);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _movieService.RemoveWithImageAsync(id);
            }
            catch (InvalidOperationException ex)
            {
                BadRequest(ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
