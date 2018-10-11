using Biblio.DAL;
using Biblio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblio.ViewModels
{
    public class FavDELETEvm
    {
        public List<Favourite> GetFava()
        {
            DB mDb = new DB();
            List<Favourite> listaDB = mDb.Ulubione.ToList();
            return listaDB;
        }
        public void DeleteFav(int id)
        {
            //DB db = new DB();
            //Favourite move = new Favourite() { favID = id };
            //db.Ulubione.Attach(move);
            //db.Ulubione.Remove(move);
            //db.SaveChanges();
            LayerBus.BusPass.UsuńUlubione(id);

        }
    }
}