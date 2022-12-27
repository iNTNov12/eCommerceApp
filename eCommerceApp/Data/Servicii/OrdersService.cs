using eCommerceApp.Models;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Data.Servicii
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Film).
                Where(n => n.IdUser == userId).ToListAsync();
            return orders;
        }

        public async Task StoreOrderAsync(List<CosItem> items, string userID, string userEmailAddress)
        {
            var order = new Order()
            {
                IdUser = userID,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach(var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Cantitate = item.Cantitate,
                    FilmId = item.Film.Id,
                    OrderId = order.Id,
                    Pret = item.Film.Pret
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
