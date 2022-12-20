using eCommerceApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Models
{
    public class Film
    {
        [Key]
        public int Id_Film { get; set; }
        public string Nume { get; set; }
        public string Descriere { get; set; }
        public double Pret { get; set; }
        public string ImagineURL { get; set; }
        public DateTime DataIncepere { get; set; }
        public DateTime DataIncheiere { get; set; }
        public CategorieFilm CategorieFilm { get; set; }

        //Relatii
        public List<Actor_Film> Actori_Filme { get; set; }

        //Cinema
        public int IdCinema{ get; set; }
        [ForeignKey("IdCinema")]
        public Cinema Cinema { get; set; }

        //Produce
        public int IdProducator { get; set; }
        [ForeignKey("IdProducator")]
        public Producator Producator { get; set; }
    }
}
