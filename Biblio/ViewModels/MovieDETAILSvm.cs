using Biblio.DAL;
using Biblio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblio.ViewModels
{
    public class MovieDETAILSvm
    {
        public List<Movie> GetMovie()
        {
            DB mDb = new DB();
            List<Movie> listaDB = mDb.Filmy.ToList();
            return listaDB;
        }
        public Movie FindMovie(int id)
        {
            //Movie u = new Movie();
            //DB db = new DB();
            //db.Filmy.Attach(u);
            //u = db.Filmy.Find(id);
            //u = bp.ZnajdźFilm(id);
            return LayerBus.BusPass.ZnajdźFilm(id);
        }
    }
}