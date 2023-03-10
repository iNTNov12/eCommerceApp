using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Adresă Email")]
        [Required(ErrorMessage = "Adresa de Email este necesară!")]
        public string EmailAddress { get; set; }

        [Display(Name = "Parolă")]
        [Required(ErrorMessage = "Parola este necesară!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
