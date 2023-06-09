﻿using Microsoft.AspNetCore.Mvc;
using mvc.Interfaces;
using mvc.Models;
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

        // Get: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Logo, Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _cinemaService.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        // GET: Cinemas/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
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
            await _cinemaService.UpdateAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        // GET: Cinemas/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
            if (cinema == null)
            {
                return View("NotFound");
            }
            return View(cinema);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
            if (cinema == null)
            {
                return View("NotFound");
            }
            await  _cinemaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
