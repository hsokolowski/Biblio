using Biblio.DAL;
using Biblio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblio.ViewModels
{
    public class MovieEDITvm
    {
        public List<Movie> GetMovie()
        {
            DB mDb = new DB();
            List<Movie> listaDB = mDb.Filmy.ToList();
            return listaDB;
        }
        public void Update(Movie a)
        {
            //DB db = new DB();
            a.data = DateTime.Now;
            //db.Entry(a).State = EntityState.Modified;
            //db.SaveChanges();
            LayerBus.BusPass.EdytujFilm(a);
        }
    }
}