using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Models
{
    public class Actor
    {
        [Key]
        public int Id_Actor { get; set; }

        [Display(Name = "Poza de Profil")]
        [Required(ErrorMessage = "Poza de Profil este obligatorie!")]

        public string PozaProfilURL { get; set; }

        [Display(Name = "Numele Întreg")]
        [Required(ErrorMessage = "Numele este obligatoriu!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Numele trebuie să conțină între 3 și 50 de litere!")]
        public string NumeIntreg { get; set; }

        [Display(Name = "Biografie")]
        [Required(ErrorMessage = "Biografia este obligatorie!")]

        public string Bio { get; set; }

        //Relatii
        public List<Actor_Film> Actori_Filme { get; set; }
    }
}
