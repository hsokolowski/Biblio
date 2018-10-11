using Biblio.DAL;
using Biblio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblio.ViewModels
{
    public class MovieDELETEvm
    {
        public List<Movie> GetMovie()
        {
            DB mDb = new DB();
            List<Movie> listaDB = mDb.Filmy.ToList();
            return listaDB;
        }
        public void DeleteMovie(int id)
        {
            //DB db = new DB();
            //Movie move = new Movie() { movieID = id };
            //db.Filmy.Attach(move);
            //db.Filmy.Remove(move);
            //db.SaveChanges();
            LayerBus.BusPass.UsuńFilm(id);
        }
    }
}