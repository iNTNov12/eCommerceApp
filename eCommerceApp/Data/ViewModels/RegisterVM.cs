using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Nume")]
        [Required(ErrorMessage = "Numele este necesar!")]
        public string FullName { get; set; }

        [Display(Name = "Adresă Email")]
        [Required(ErrorMessage = "Adresa de Email este necesară!")]
        public string EmailAddress { get; set; }

        [Display(Name = "Parolă")]
        [Required(ErrorMessage = "Parola este necesară!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Display(Name = "Confirmă Parola")]
        [Required(ErrorMessage = "Este necesară confirmarea parolei!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parolele nu se potrivesc!")]
        public string ConfirmPassword { get; set; }
    }
}
