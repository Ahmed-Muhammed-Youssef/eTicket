﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Interfaces;

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
    }
}
