using eCommerceApp.Data.Base;
using eCommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Data.Servicii
{
    public class CinematografeService:EntityBaseRepository<Cinema>, ICinematografeService
    {

        public CinematografeService(AppDbContext context) : base(context)
        {
        }
    }
}
