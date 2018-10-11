using Biblio.DAL;
using Biblio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblio.ViewModels
{
    public class MovieAdd
    {
        public List<Movie> GetMovie()
        {
            DB mDb = new DB();
            List<Movie> listaDB = mDb.Filmy.ToList();
            return listaDB;
        }
        public void AddUser(Movie u)
        {
            //DB mDb = new DB();
            u.data = DateTime.Now;
            //mDb.Filmy.Add(u);
            //mDb.Configuration.ValidateOnSaveEnabled = false;
            LayerBus.BusPass.DodajFilm(u);
            //mDb.SaveChanges();
        }

        
    }
}