using eCommerceApp.Data;
using eCommerceApp.Data.Servicii;
using eCommerceApp.Data.Static;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class FilmeController : Controller
    {
        private readonly IFilmeService _service;

        public FilmeController(IFilmeService service) //constructor
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var tfilmele = await _service.GetAllAsync(n => n.Cinema);
            return View(tfilmele);
        }

        public async Task<IActionResult> Filtru(string searchString)
        {
            var tfilmele = await _service.GetAllAsync(n => n.Cinema);

            if(!string.IsNullOrEmpty(searchString))
            {
                var resultatFiltrat = tfilmele.Where(n => n.Nume.Contains(searchString) || n.Descriere.Contains(searchString)).ToList();
                return View("Index", resultatFiltrat);
            }

            return View("Index", tfilmele);
        }

        //Get: Filme/Detalii/1
        [AllowAnonymous]
        public async Task<IActionResult> Detalii(int id)
        {
            var filmDet = await _service.GetFilmByIdAsync(id);
            return View(filmDet);
        }

        //Get: Film/Creeaza
        public async Task<IActionResult> Creeaza()
        {
            var FilmDropdownData = await _service.GetNewMovieDropdownsValues();

            ViewBag.IdCinema = new SelectList(FilmDropdownData.Cinematografe, "Id", "Nume");
            ViewBag.IdProducator = new SelectList(FilmDropdownData.Producatori, "Id", "NumeIntreg");
            ViewBag.IdActor = new SelectList(FilmDropdownData.Actori, "Id", "NumeIntreg");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Creeaza(NFilmVM film)
        {
            if(!ModelState.IsValid)
            {
                var FilmDropdownData = await _service.GetNewMovieDropdownsValues();

                ViewBag.IdCinema = new SelectList(FilmDropdownData.Cinematografe, "Id", "Nume");
                ViewBag.IdProducator = new SelectList(FilmDropdownData.Producatori, "Id", "NumeIntreg");
                ViewBag.IdActor = new SelectList(FilmDropdownData.Actori, "Id", "NumeIntreg");

                return View();
            }

            await _service.AddNewMovieAsync(film);
            return RedirectToAction(nameof(Index));
        }

        //Get: Film/Editeaza/1
        public async Task<IActionResult> Editeaza(int id)
        {
            var filmDet = await _service.GetFilmByIdAsync(id);
            if (filmDet == null) 
                return View("NotFound");

            var respone = new NFilmVM()
            {
                Id = filmDet.Id,
                Nume = filmDet.Nume,
                Descriere = filmDet.Descriere,
                Pret = filmDet.Pret,
                DataIncepere = filmDet.DataIncepere,
                DataIncheiere = filmDet.DataIncheiere,
                ImagineURL = filmDet.ImagineURL,
                CategorieFilm = filmDet.CategorieFilm,
                IdCinema = filmDet.IdCinema,
                IdProducator = filmDet.IdProducator,
                ActorIds = filmDet.Actori_Filme.Select(n => n.IdActor).ToList(),
            };

            var FilmDropdownData = await _service.GetNewMovieDropdownsValues();
            ViewBag.IdCinema = new SelectList(FilmDropdownData.Cinematografe, "Id", "Nume");
            ViewBag.IdProducator = new SelectList(FilmDropdownData.Producatori, "Id", "NumeIntreg");
            ViewBag.IdActor = new SelectList(FilmDropdownData.Actori, "Id", "NumeIntreg");

            return View(respone);
        }

        [HttpPost]
        public async Task<IActionResult> Editeaza(int id, NFilmVM film)
        {
            if (id != film.Id)
                return View("NotFound");

            if (!ModelState.IsValid)
            {
                var FilmDropdownData = await _service.GetNewMovieDropdownsValues();

                ViewBag.IdCinema = new SelectList(FilmDropdownData.Cinematografe, "Id", "Nume");
                ViewBag.IdProducator = new SelectList(FilmDropdownData.Producatori, "Id", "NumeIntreg");
                ViewBag.IdActor = new SelectList(FilmDropdownData.Actori, "Id", "NumeIntreg");

                return View();
            }

            await _service.UpdateMovieAsync(film);
            return RedirectToAction(nameof(Index));
        }
    }
}
