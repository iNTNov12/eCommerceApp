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
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Actori/Creeaza - Actiune
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
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actori/Detalii/1
        public async Task<IActionResult> Detalii(int id)
        {
            var actorDet = await _service.GetByIdAsync(id);

            if (actorDet == null)
                return View("NotFound");
            return View(actorDet);
        }

        //Get: Actori/Editeaza/1 - Actiune
        public async Task<IActionResult> Editeaza(int id)
        {
            var actorDet = await _service.GetByIdAsync(id);
            if (actorDet == null)   
                return View("NotFound");
            return View(actorDet);
        }

        [HttpPost]
        public async Task<IActionResult> Editeaza(int id, Actor actor)
        {
            actor.Id = id;
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actori/Sterge/1 - Actiune
        public async Task<IActionResult> Sterge(int id)
        {
            var actorDeta = await _service.GetByIdAsync(id);
            if (actorDeta == null) 
                return View("NotFound");
            return View(actorDeta);
        }

        [HttpPost, ActionName("Sterge")]
        public async Task<IActionResult> StergereConfirmata(int id)
        {
            var actorDet = await _service.GetByIdAsync(id);
            if (actorDet == null) 
                return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
