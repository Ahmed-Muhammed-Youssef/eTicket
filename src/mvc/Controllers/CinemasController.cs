﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc.Data.Static;
using mvc.Data.ViewModels;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Controllers
{
    [Authorize(Roles = UserRolesValues.Admin)]
    public class CinemasController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemasController(ICinemaService cinemaService)
        {
            this._cinemaService = cinemaService;
        }
        public async Task<IActionResult> Index()
        {
            var cinemas = await _cinemaService.GetAllAsync(trackChanges: false, d => d.Image);
            return View(cinemas);
        }
        [AllowAnonymous]
        // GET: Cinemas/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id, trackChanges: false, d => d.Image);
            if (cinema != null)
            {
                return View(cinema);
            }
            return View("NotFound");
        }

        // Get: Cinemas/Create
        public IActionResult Create()
        {
            return View(new CinemaVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CinemaVM cinemaVM)
        {
            var cinema = new Cinema
            {
                Name = cinemaVM.Name,
                Description = cinemaVM.Description,
                Image = new Image() { ImageFile = cinemaVM.Image.ImageFile }
            };
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _cinemaService.AddWithImageUplodaing(cinema);
            return RedirectToAction(nameof(Index));
        }

        // GET: Cinemas/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id, trackChanges: false, d => d.Image);
            if (cinema == null)
            {
                return View("NotFound");
            }
            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _cinemaService.UpdateWithImageAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        // GET: Cinemas/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id, trackChanges: false, d => d.Image);
            if (cinema == null)
            {
                return View("NotFound");
            }
            return View(cinema);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id, trackChanges: false, d => d.Image);
            if (cinema == null)
            {
                return View("NotFound");
            }
            await  _cinemaService.DeleteAsyncWithImage(cinema);
            return RedirectToAction(nameof(Index));
        }

    }
}
