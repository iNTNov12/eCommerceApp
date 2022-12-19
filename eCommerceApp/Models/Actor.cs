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
        public string PozaProfilURL { get; set; }
        public string NumeIntreg { get; set; }
        public string Bio{ get; set; }
    }
}
