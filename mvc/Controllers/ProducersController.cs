using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Interfaces;
using mvc.Models;
using mvc.Services;

namespace mvc.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerService _producerService;

        public ProducersController(IProducerService producerService)
        {
            this._producerService = producerService;
        }
        public async Task<IActionResult> Index()
        {
            var producers = await _producerService.GetAllAsync();
            return View(producers);
        }
        
        // GET: Producers/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var producer = await _producerService.GetByIdAsync(id);
            if(producer != null)
            {
                return View(producer);
            }
            return View("NotFound");
        }

        // GET: Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producers/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureUrl, Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _producerService.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        // GET: Producers/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var producer = await _producerService.GetByIdAsync(id);
            if (producer == null)
            {
                return View("NotFound");
            }
            return View(producer);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _producerService.UpdateAsync(producer);
            return RedirectToAction(nameof(Index));
        }
    }
}
