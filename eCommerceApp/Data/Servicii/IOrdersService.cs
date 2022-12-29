using eCommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Data.Servicii
{
    public interface IOrdersService
    {
        //Adauga orders in DB
        Task StoreOrderAsync(List<CosItem> items, string userID, string userEmailAddress);

        //Preia orders in DB
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}
