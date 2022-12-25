using eCommerceApp.Data.Base;
using eCommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Data.Servicii
{
    public class ActoriService : EntityBaseRepository<Actor>, IActoriService
    {
        public ActoriService(AppDbContext context) : base(context) { }
    }
}
