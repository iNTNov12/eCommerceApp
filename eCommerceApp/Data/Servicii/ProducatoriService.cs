using eCommerceApp.Data.Base;
using eCommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Data.Servicii
{
    public class ProducatoriService : EntityBaseRepository<Producator>, IProducatoriService
    {
        public ProducatoriService(AppDbContext context) : base(context)
        {

        }
    }
}
