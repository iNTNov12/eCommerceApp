using eCommerceApp.Data;
using eCommerceApp.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Models
{
    public class NFilmVM
    {
        public int Id { get; set; }

        [Display(Name = "Nume Film")]
        [Required(ErrorMessage = "Numele este obligatoriu!")]
        public string Nume { get; set; }

        [Display(Name = "Descriere")]
        [Required(ErrorMessage = "Descrierea filmului este obligatorie!")]
        public string Descriere { get; set; }

        [Display(Name = "Pret")]
        [Required(ErrorMessage = "Pretul este obligatoriu!")]
        public double Pret { get; set; }

        [Display(Name = "Poster Film")]
        [Required(ErrorMessage = "Posterul (URL) este obligatoriu!")]
        public string ImagineURL { get; set; }

        [Display(Name = "Dată Începere")]
        [Required(ErrorMessage = "Data de începre este obligatorie!")]
        public DateTime DataIncepere { get; set; }

        [Display(Name = "Dată Încheiere")]
        [Required(ErrorMessage = "Data de încheiere este obligatorie!")]
        public DateTime DataIncheiere { get; set; }

        [Display(Name = "Selectează o categorie")]
        [Required(ErrorMessage = "Categoria filmului este obligatoriu!")]
        public CategorieFilm CategorieFilm { get; set; }

        //Relatii

        [Display(Name = "Selectează actor/actorii: ")]
        [Required(ErrorMessage = "Actorul filmului este obligatoriu!")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Selectează un cinematograf: ")]
        [Required(ErrorMessage = "Cinematograful unde se va difuza filmul este obligatoriu!")]
        public int IdCinema { get; set; }

        [Display(Name = "Selectează un producător: ")]
        [Required(ErrorMessage = "Producătorul filmului este obligatoriu!")]
        public int IdProducator { get; set; }

    }
}