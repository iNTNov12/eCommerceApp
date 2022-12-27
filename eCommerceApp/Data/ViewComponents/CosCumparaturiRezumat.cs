using eCommerceApp.Data.Cos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Data.ViewComponents
{
    public class CosCumparaturiRezumat:ViewComponent
    {
        private readonly CosCumparaturi _cosCumparaturi;

        public CosCumparaturiRezumat(CosCumparaturi cosCumparaturi)
        {
            _cosCumparaturi = cosCumparaturi;
        }

        public IViewComponentResult Invoke()
        {
            var items = _cosCumparaturi.GetCosItems();

            return View(items.Count);
        }
    }
}
