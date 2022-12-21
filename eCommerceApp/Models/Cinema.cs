using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Models
{
    public class Cinema
    {
        [Key]
        public int Id_Cinema { get; set; }

        [Display(Name = "Logo Cinematograf")]
        public string Logo { get; set; }

        [Display(Name = "Denumire")]
        public string Nume { get; set; }

        [Display(Name = "Descriere")]
        public string Descriere { get; set; }
        
        //Relatii
        public List<Film> Filme { get; set; }
    }
}
