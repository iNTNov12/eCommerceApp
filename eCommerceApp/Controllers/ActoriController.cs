using eCommerceApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Controllers
{
    public class ActoriController : Controller
    {
        private readonly AppDbContext _context;

        public ActoriController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Actori.ToList();
            return View(data);
        }
    }
}
