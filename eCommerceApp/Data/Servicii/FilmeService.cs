using eCommerceApp.Data.Base;
using eCommerceApp.Data.ViewModels;
using eCommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Data.Servicii
{
    public class FilmeService : EntityBaseRepository<Film>, IFilmeService
    {
        private readonly AppDbContext _context;
        public FilmeService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NFilmVM data)
        { //adauga data in BD
            var newFilm = new Film()
            {
                Nume = data.Nume,
                Descriere = data.Descriere,
                Pret = data.Pret,
                ImagineURL = data.ImagineURL,
                IdCinema = data.IdCinema,
                DataIncepere = data.DataIncepere,
                DataIncheiere = data.DataIncheiere,
                CategorieFilm = data.CategorieFilm,
                IdProducator = data.IdProducator
            };
            await _context.Filme.AddAsync(newFilm);
            await _context.SaveChangesAsync();

            //Adauga Actori in Film
            foreach (var actorId in data.ActorIds)
            {
                var newActorFilm = new Actor_Film()
                {
                    IdFilm = newFilm.Id,
                    IdActor = actorId
                };
                await _context.Actori_Filme.AddAsync(newActorFilm);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Film> GetFilmByIdAsync(int id)
        {
            var filmDetalii = await _context.Filme
                .Include(c => c.Cinema)
                .Include(p => p.Producator)
                .Include(am => am.Actori_Filme).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return filmDetalii;
        }

        public async Task<NFilmDropdownVM> GetNewMovieDropdownsValues()
        {
            var response = new NFilmDropdownVM()
            {
                Actori = await _context.Actori.OrderBy(n => n.NumeIntreg).ToListAsync(),
                Cinematografe = await _context.Cinematografe.OrderBy(n => n.Nume).ToListAsync(),
                Producatori = await _context.Producatori.OrderBy(n => n.NumeIntreg).ToListAsync()
            };
            

            return response;
        }

        public async Task UpdateMovieAsync(NFilmVM data)
        {
            var dbFilm = await _context.Filme.FirstOrDefaultAsync(n=>n.Id ==data.Id);

            if(dbFilm != null)
            {
                dbFilm.Nume = data.Nume;
                dbFilm.Descriere = data.Descriere;
                dbFilm.Pret = data.Pret;
                dbFilm.ImagineURL = data.ImagineURL;
                dbFilm.IdCinema = data.IdCinema;
                dbFilm.DataIncepere = data.DataIncepere;
                dbFilm.DataIncheiere = data.DataIncheiere;
                dbFilm.CategorieFilm = data.CategorieFilm;
                dbFilm.IdProducator = data.IdProducator;
                await _context.SaveChangesAsync();
            }

            //Sterge Actori
            var exActoridb = _context.Actori_Filme.Where(n => n.IdFilm == data.Id).ToList();
            _context.Actori_Filme.RemoveRange(exActoridb);
            await _context.SaveChangesAsync();

            //Adauga Actori in Film
            foreach (var actorId in data.ActorIds)
            {
                var newActorFilm = new Actor_Film()
                {
                    IdFilm = data.Id,
                    IdActor = actorId
                };
                await _context.Actori_Filme.AddAsync(newActorFilm);
            }
            await _context.SaveChangesAsync();
        }
    }
}
