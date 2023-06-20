using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
            this._actorService = actorService;
        }

        // GET: Actors/Index
        public async Task<IActionResult> Index()
        {
            var actors = await _actorService.GetAllAsync();
            return View(actors);
        }
        // GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureUrl, Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _actorService.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
    }
}
