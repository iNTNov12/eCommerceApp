using eCommerceApp.Data.Cos;
using eCommerceApp.Data.Servicii;
using eCommerceApp.Data.Static;
using eCommerceApp.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eCommerceApp.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IFilmeService _filmeService;
        private readonly CosCumparaturi _cosCumparaturi;
        private readonly IOrdersService _ordersService;

        public OrdersController(IFilmeService filmeService, CosCumparaturi cosCumparaturi, IOrdersService ordersService)
        {
            _filmeService = filmeService;
            _cosCumparaturi = cosCumparaturi;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }

        public IActionResult CosCumparaturi()
        {
            var items = _cosCumparaturi.GetCosItems();
            _cosCumparaturi.CosItems = items;


            var respone = new CosVM()
            {
                CosCumparaturi = _cosCumparaturi,
                CosCumparaturiTotal = _cosCumparaturi.GetCosTotal()
            };

            return View(respone);
        }

        public async Task<IActionResult> AddToCosCumparaturi(int id)
        {
            var item = await _filmeService.GetFilmByIdAsync(id);

            if(item != null)
            {
                _cosCumparaturi.AddItemToCos(item);
            }
            return RedirectToAction(nameof(CosCumparaturi));
        }

        public async Task<IActionResult> RemoveCosCumparaturi(int id)
        {
            var item = await _filmeService.GetFilmByIdAsync(id);

            if (item != null)
            {
                _cosCumparaturi.RemoveItemCos(item);
            }
            return RedirectToAction(nameof(CosCumparaturi));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _cosCumparaturi.GetCosItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _cosCumparaturi.EliminaCosCumparaturiAsync();

            return View("OrderCompleted");
        }
    }
}
