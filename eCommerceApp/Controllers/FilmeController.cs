using eCommerceApp.Data;
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
        private readonly AppDbContext _context;

        public FilmeController(AppDbContext context) //constructor
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tfilmele = await _context.Filme.Include(n => n.Cinema).OrderBy(n => n.Nume).ToListAsync();
            return View(tfilmele);
        }
    }
}
