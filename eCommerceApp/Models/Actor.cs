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

        public string PozaProfilURL { get; set; }

        [Display(Name = "Numele Întreg")]

        public string NumeIntreg { get; set; }

        [Display(Name = "Biografie")]

        public string Bio { get; set; }

        //Relatii
        public List<Actor_Film> Actori_Filme { get; set; }
    }
}
