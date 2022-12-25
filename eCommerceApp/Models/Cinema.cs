using eCommerceApp.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo Cinematograf")]
        [Required(ErrorMessage = "Logo-ul este obligatoriu!")]
        public string Logo { get; set; }

        [Display(Name = "Denumire")]
        [Required(ErrorMessage = "Denumirea este obligatorie!")]
        
        public string Nume { get; set; }

        [Display(Name = "Descriere")]
        [Required(ErrorMessage = "Descrierea este obligatorie!")]
        public string Descriere { get; set; }
        
        //Relatii
        public List<Film> Filme { get; set; }
    }
}
