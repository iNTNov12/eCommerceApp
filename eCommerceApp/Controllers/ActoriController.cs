using eCommerceApp.Data;
using eCommerceApp.Data.Servicii;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Controllers
{
    public class ActoriController : Controller
    {
        private readonly IActoriService _service;

        public ActoriController(IActoriService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        //Get: Actors/Create
        public IActionResult Creeaza()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Creeaza([Bind("NumeIntreg,PozaProfilURL,Bio")]Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            _service.Add(actor);
            return RedirectToAction(nameof(Index));
        }
    }
}
