using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Models
{
    public class Actor_Film
    {
        public int IdFilm { get; set; }
        public  Film Film { get; set; }

        public int IdActor { get; set; }
        public Actor Actor { get; set; }
    }
}
