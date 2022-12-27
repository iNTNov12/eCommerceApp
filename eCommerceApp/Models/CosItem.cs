using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Models
{
    public class CosItem
    {
        [Key]

        public int Id { get; set; }

        public Film Film { get; set; }
        public int Cantitate { get; set; }



        public string CosId { get; set; }
    }
}
