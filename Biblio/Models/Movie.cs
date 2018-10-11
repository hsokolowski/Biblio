using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Biblio.Models
{
    public class Movie
    {
        [Key]
        [Display(Name = "ID")]
        public int movieID { get; set; }

        [Display(Name = "Tytuł")]
        public string Name { get; set; }

        [Display(Name = "Autor")]
        public string Autor { get; set; }

        [Display(Name = "Rok")]
        [Range(0, 99999, ErrorMessage = "Rok nie może być ujemny!")]
        public int Year { get; set; }

        [Display(Name = "Czas")]
        [Range(1, 99999, ErrorMessage = "Czas nie może być ujemny!")]
        public int Time { get; set; }

        
        [Display(Name = "Typ")]
        public string TypeString
        {
            get
            {
                return Type.ToString();
            }
            private set
            {
                Type = value.ParseEnum<Typ>();
            }
            
        }
        [NotMapped]
        public Typ Type { get; set; }

        [Display(Name = "Wiek")]
        [Range(1, 18, ErrorMessage = "Wiek powienien być większy od {1} i mnijeszy od {2}!")]
        public int Age { get; set; }

        [Display(Name = "Data")]
        public DateTime data { get; set; }

        [Display(Name = "Kto")]
        public int kto { get; set; }

        public string agecolor
        {
            get
            {
                if(Age<=11)
                {
                    return "green";
                }
                else if (Age>=12&&Age<16)
                {
                    return "orange";
                }
                else
                {
                    return "red";
                }
            }
        }
       
  
    }
    public enum Typ
    {
            Horror=1,
            Komedia=2,
            Obyczajowy=3,
            Thriller=4,
            Romantyczny=5,
            Dokumentalny=6
    }
    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}