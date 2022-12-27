using eCommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Data.ViewModels
{
    public class NFilmDropdownVM
    {
        public NFilmDropdownVM()  // nu definim si pentru Filme pentru ca este un tip Enum
        {
            Producatori = new List<Producator>();
            Cinematografe = new List<Cinema>();
            Actori = new List<Actor>();
        }

        public List<Producator> Producatori { get; set; }
        public List<Cinema> Cinematografe { get; set; }
        public List<Actor> Actori { get; set; }
    }
}
