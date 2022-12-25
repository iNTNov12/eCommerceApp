using eCommerceApp.Data;
using eCommerceApp.Data.Servicii;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Controllers
{
    public class FilmeController : Controller
    {
        private readonly IFilmeService _service;

        public FilmeController(IFilmeService service) //constructor
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var tfilmele = await _service.GetAllAsync(n => n.Cinema);
            return View(tfilmele);
        }

        //Get: Filme/Detalii/1
        public async Task<IActionResult> Detalii(int id)
        {
            var filmDet = await _service.GetFilmByIdAsync(id);
            return View(filmDet);
        }
    }
}
