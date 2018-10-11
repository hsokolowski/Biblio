using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblio.ViewModels
{
    public class GlobalModels
    {
        public IEnumerable<Biblio.Models.Movie> Films { get; set; }
        public IEnumerable<Biblio.Models.Favourite> Ulubs { get; set; }
    }
}