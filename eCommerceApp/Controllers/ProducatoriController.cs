using eCommerceApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Controllers
{
    public class ProducatoriController : Controller
    {
        private readonly AppDbContext _context;

        public ProducatoriController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var totiproducatorii = _context.Producatori.ToList();
            return View(totiproducatorii);
        }
    }
}
