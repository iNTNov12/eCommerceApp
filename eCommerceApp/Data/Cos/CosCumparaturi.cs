using eCommerceApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Data.Cos
{
    public class CosCumparaturi
    {
        public AppDbContext _context { get; set; }

        public string IdCosCumparaturi { get; set; }

        public List<CosItem> CosItems { get; set; }

        public CosCumparaturi(AppDbContext context)
        {
            _context = context;
        }

        public static CosCumparaturi GetCosCumparaturi(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cosId = session.GetString("CosId") ?? Guid.NewGuid().ToString();
            session.SetString("CosId", cosId);

            return new CosCumparaturi(context) { IdCosCumparaturi = cosId };
        }

        public void AddItemToCos(Film film)
        {
            var CosItem = _context.CosItems.FirstOrDefault(n => n.Film.Id == film.Id && 
              n.CosId == IdCosCumparaturi);

            if (CosItem == null)
            {
                CosItem = new CosItem()
                {
                    CosId = IdCosCumparaturi,
                    Film = film,
                    Cantitate = 1
                };

                _context.CosItems.Add(CosItem);
            }
            else
                CosItem.Cantitate++;

            _context.SaveChanges();
        }

        public void RemoveItemCos(Film film)
        {
            var CosItem = _context.CosItems.FirstOrDefault(n => n.Film.Id == film.Id &&
              n.CosId == IdCosCumparaturi);

            if (CosItem != null)
            {
                if (CosItem.Cantitate > 1)
                {
                    CosItem.Cantitate--;
                }
                else
                    _context.CosItems.Remove(CosItem);
            }
            _context.SaveChanges();
        }

        //Get: Iteme din Cos
        public List<CosItem> GetCosItems()
        {
            return CosItems ?? (CosItems = _context.CosItems.
                Where(n => n.CosId == IdCosCumparaturi).
                Include(n => n.Film).ToList());
        }

        //Get: Total Cos
        public double GetCosTotal() => _context.CosItems.Where(n => n.CosId == IdCosCumparaturi).Select(n => n.Film.Pret * n.Cantitate).Sum();
        
        public async Task EliminaCosCumparaturiAsync()
        {
            var items = await _context.CosItems.Where(n => n.CosId == IdCosCumparaturi).ToListAsync();
            _context.CosItems.RemoveRange(items);
            await _context.SaveChangesAsync();

            CosItems = new List<CosItem>();
        }
    }
}
