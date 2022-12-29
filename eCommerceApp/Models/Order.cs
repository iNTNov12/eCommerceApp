using eTickets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string IdUser { get; set; } //logged in user id
        [ForeignKey(nameof(IdUser))]
        public ApplicationUser User { get; set; }


        //Relatii
        public List<OrderItem> OrderItems { get; set; }
    }
}
