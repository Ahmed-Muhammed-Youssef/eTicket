using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc.Data.Static;
using mvc.Data.ViewModels;
using mvc.Interfaces;
using mvc.Models;
using mvc.Services;

namespace mvc.Controllers
{
    [Authorize(Roles = UserRolesValues.Admin)]
    public class DirectorsController : Controller
    {
        private readonly IDirectorService _directorService;

        public DirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;
        }
        public async Task<IActionResult> Index()
        {
            var director = await _directorService.GetAllAsync(trackChanges: false, d => d.Image);
            return View(director);
        }

        // GET: Directors/Details/{id}
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var director = await _directorService.GetByIdAsync(id, trackChanges: false, d => d.Image);
            if(director != null)
            {
                return View(director);
            }
            return View("NotFound");
        }

        // GET: Directors/Create
        public IActionResult Create()
        {
            return View(new DirectorVM());
        }

        // POST: Directors/Create
        [HttpPost]
        public async Task<IActionResult> Create(DirectorVM directorVM)
        {
            var director = new Director()
            {
                FullName = directorVM.FullName,
                Bio = directorVM.Bio,
                Image = new Image() { ImageFile = directorVM.Image.ImageFile }
            };
            if (!ModelState.IsValid)
            {
                return View(director);
            }
            await _directorService.AddDirectorWithImageUplodaing(director);
            return RedirectToAction(nameof(Index));
        }

        // GET: Directors/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var director = await _directorService.GetByIdAsync(id, trackChanges: false, d => d.Image);
            if (director == null)
            {
                return View("NotFound");
            }
            return View(director);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Director director)
        {
            if (!ModelState.IsValid)
            {
                return View(director);
            }

            await _directorService.UpdateDirectorWithImageAsync(director);
            return RedirectToAction(nameof(Index));
        }

        // GET: Directors/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var director = await _directorService.GetByIdAsync(id, trackChanges: false, d => d.Image);
            if (director == null)
            {
                return View("NotFound");
            }
            return View(director);
        }

        // POST: Directors/Delete/{id}
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var director = await _directorService.GetByIdAsync(id, trackChanges: false, d => d.Image);
            if (director == null)
            {
                return View("NotFound");
            }
            await _directorService.DeleteAsyncWithImage(director);
            return RedirectToAction(nameof(Index));
        }
    }
}
