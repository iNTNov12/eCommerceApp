using eCommerceApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
