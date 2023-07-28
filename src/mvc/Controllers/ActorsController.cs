using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc.Data.Static;
using mvc.Data.ViewModels;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Controllers
{
    [Authorize(Roles = UserRolesValues.Admin)]
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ActorsController(IActorService actorService, IWebHostEnvironment hostEnvironment)
        {
            this._actorService = actorService;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Actors/Index
        public async Task<IActionResult> Index()
        {
            var actors = await _actorService.GetAllAsync(a => a.Image);
            return View(actors);
        }
        
        // GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(ActorVM actorVM)
        {
            var actor = new Actor()
            {
                FullName = actorVM.FullName,
                Bio = actorVM.Bio,
                Image = new Image() { ImageFile = actorVM.ImageFile }
            };
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _actorService.AddActorWithImageUplodaing(actor);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        // GET: Actors/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);
            if(actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }
        
        
        // GET: Actors/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var actor  = await _actorService.GetByIdAsync(id);
            if(actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _actorService.UpdateAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        // GET: Actors/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);
            if(actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            await _actorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
