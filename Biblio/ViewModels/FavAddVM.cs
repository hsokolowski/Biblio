using Biblio.DAL;
using Biblio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblio.ViewModels
{
    public class FavAddVM
    {
        public List<Favourite> GetFava()
        {
            DB mDb = new DB();
            List<Favourite> listaDB = mDb.Ulubione.ToList();
            return listaDB;
        }
        public void UlubDodaj(int id, int whu)
        {
            //DB db = new DB();
            //Favourite f = new Favourite();
            //f.which = id;
            //f.who = whu;
            //db.Ulubione.Add(f);
            //db.SaveChanges();
            LayerBus.BusPass.DodajUlubione(id, whu);
        }
    }
}