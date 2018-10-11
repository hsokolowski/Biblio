using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblio.Models
{
    public class Favourite
    {
        [Key]
        public int favID { get; set; }
        [Display(Name = "Kto dodał")]
        public int who { get; set; }
        [Display(Name = "Który film")]
        public int which { get; set; }
    }
}