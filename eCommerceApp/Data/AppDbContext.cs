using eCommerceApp.Models;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Film>().HasKey(af => new
            {
                af.IdActor,
                af.IdFilm
            });

            modelBuilder.Entity<Actor_Film>().HasOne(f => f.Film).WithMany(af => af.Actori_Filme).HasForeignKey(f => f.IdFilm);
            modelBuilder.Entity<Actor_Film>().HasOne(f => f.Actor).WithMany(af => af.Actori_Filme).HasForeignKey(f => f.IdActor);

            base.OnModelCreating(modelBuilder);
        }

        //Denumire tabele

        public DbSet<Actor> Actori { get; set; }
        public DbSet<Film> Filme { get; set; }
        public DbSet<Actor_Film> Actori_Filme{ get; set; }
        public DbSet<Cinema> Cinematografe { get; set; }
        public DbSet<Producator> Producatori{ get; set; }


        //Tabele legate de Comanda
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CosItem> CosItems { get; set; }
    }
}
