using eCommerceApp.Data;
using eCommerceApp.Data.Servicii;
using eCommerceApp.Data.Static;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CinematografeController : Controller
    {
        private readonly ICinematografeService _service;

        public CinematografeController(ICinematografeService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var tcinematografe = await _service.GetAllAsync();
            return View(tcinematografe);
        }


        //Get: Cinema/Creeaza
        public IActionResult Creeaza()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Creeaza([Bind("Logo,Nume,Descriere")]Cinema cinema)
        {
            if (!ModelState.IsValid)
                return View(cinema);
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }


        //Get: Cinema/Detalii/1
        [AllowAnonymous]
        public async Task<IActionResult> Detalii(int id)
        {
            var cinemaDet = await _service.GetByIdAsync(id);
            if (cinemaDet == null)
                return View("NotFound");
            return View(cinemaDet);
        }

        //Get: Cinema/Editeaza/1
        public async Task<IActionResult> Editeaza(int id)
        {
            var cinemaDet = await _service.GetByIdAsync(id);
            if (cinemaDet == null)
                return View("NotFound");
            return View(cinemaDet);
        }

        [HttpPost]
        public async Task<IActionResult> Editeaza(int id, [Bind("Id,Logo,Nume,Descriere")] Cinema cinema)
        {
            if (!ModelState.IsValid)
                return View(cinema);
            await _service.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinema/Sterge/1
        public async Task<IActionResult> Sterge(int id)
        {
            var cinemaDet = await _service.GetByIdAsync(id);
            if (cinemaDet == null)
                return View("NotFound");
            return View(cinemaDet);
        }

        [HttpPost, ActionName("Sterge")]
        public async Task<IActionResult> StergereConfirmata(int id)
        {
            var cinemaDet = await _service.GetByIdAsync(id);
            if (cinemaDet == null)
                return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
