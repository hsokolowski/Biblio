using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblio.Models
{
    public class Admin
    {
        [Key]
        public int adminID { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage ="To pole jest wymagane!")]
        public string login { get; set; }

        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        [StringLength(100, ErrorMessage = "Hasło musi mieć minimum {2} znaków", MinimumLength = 5)]
        public string password { get; set; }

        [Display(Name = "Potwierdź Hasło")]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirmedpassword { get; set; }
    }
}