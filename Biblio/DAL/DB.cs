using Biblio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblio.DAL
{
    public class DB : DbContext
    {
        public DB() : base("MyDB")
        {

        }
        
        public DbSet<Movie> Filmy { get; set; }
        public DbSet<Admin> Admini { get; set; }
        public DbSet<Favourite> Ulubione { get; set; }
    }
}