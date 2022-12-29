using eCommerceApp.Data;
using eCommerceApp.Data.Servicii;
using eCommerceApp.Data.Static;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducatoriController : Controller
    {
        private readonly IProducatoriService _service;

        public ProducatoriController(IProducatoriService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var totiproducatorii = await _service.GetAllAsync();
            return View(totiproducatorii);
        }

        //GET: producatori/detalii/1
        [AllowAnonymous]
        public async Task<IActionResult> Detalii(int id)
        {
            var producatorDet = await _service.GetByIdAsync(id);
            if (producatorDet == null)
                return View("NotFound");
            return View(producatorDet);
        }

        //GET: producatori/creeaza

        public IActionResult Creeaza()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Creeaza([Bind("PozaProfilURL,NumeIntreg,Bio")]Producator producator)
        {
            if (!ModelState.IsValid)
                return View(producator);

            await _service.AddAsync(producator);
            return RedirectToAction(nameof(Index));
        }

        //GET: producatori/editeaza/1

        public async Task<IActionResult> Editeaza(int id)
        {
            var producatorDet = await _service.GetByIdAsync(id);
            if (producatorDet == null)
                return View("Not Found");
            return View(producatorDet);
        }

        [HttpPost]
        public async Task<IActionResult> Editeaza(int id, [Bind("Id,PozaProfilURL,NumeIntreg,Bio")] Producator producator)
        {
            if (!ModelState.IsValid)
                return View(producator);

            if(id == producator.Id)
            {
                await _service.UpdateAsync(id, producator);
                return RedirectToAction(nameof(Index));
            }
            return View(producator);
        }

        //GET: producatori/sterge/1

        public async Task<IActionResult> Sterge(int id)
        {
            var producatorDet = await _service.GetByIdAsync(id);
            if (producatorDet == null)
                return View("Not Found");
            return View(producatorDet);
        }

        [HttpPost, ActionName("Sterge")]
        public async Task<IActionResult> StergereConfirmata(int id)
        {
            var producatorDet = await _service.GetByIdAsync(id);
            if (producatorDet == null)
                return View("Not Found");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
