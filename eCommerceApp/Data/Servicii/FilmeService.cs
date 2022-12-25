using eCommerceApp.Data.Base;
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

        public async Task<Film> GetFilmByIdAsync(int id)
        {
            var filmDetalii = await _context.Filme
                .Include(c => c.Cinema)
                .Include(p => p.Producator)
                .Include(am => am.Actori_Filme).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return filmDetalii;
        }
    }
}
