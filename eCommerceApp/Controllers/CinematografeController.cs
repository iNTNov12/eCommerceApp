using eCommerceApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Controllers
{
    public class CinematografeController : Controller
    {
        private readonly AppDbContext _context;

        public CinematografeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tcinematografe = await _context.Cinematografe.ToListAsync();
            return View(tcinematografe);
        }
    }
}
