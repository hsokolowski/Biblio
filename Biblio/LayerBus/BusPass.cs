using Biblio.DAL;
using Biblio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblio.LayerBus
{
    public class BusPass
    {
        public static void DodajFilm(Movie u)
        {
            DB mDb = new DB();
            mDb.Filmy.Add(u);
            mDb.SaveChanges();
        }
        public static Movie ZnajdźFilm(int id)
        {
            Movie b = new Movie();
            DB db = new DB();
            db.Filmy.Attach(b);
            b= db.Filmy.Find(id);
            return b;
        }
        public static void EdytujFilm(Movie a)
        {
            DB db = new DB();
            db.Entry(a).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static void UsuńFilm(int id)
        {
            DB db = new DB();
            Movie move = new Movie() { movieID = id };
            db.Filmy.Attach(move);
            db.Filmy.Remove(move);
            db.SaveChanges();
        }
        public static void UsuńUlubione(int id)
        {
            DB db = new DB();
            Favourite move = new Favourite() { favID = id };
            db.Ulubione.Attach(move);
            db.Ulubione.Remove(move);
            db.SaveChanges();
        }
        public static void DodajUlubione(int id,int whu)
        {
            DB db = new DB();
            Favourite f = new Favourite();
            f.which = id;
            f.who = whu;
            db.Ulubione.Add(f);
            db.SaveChanges();
        }
        public static void DodajAdmina(Admin u)
        {
            DB mDb = new DB();
            mDb.Admini.Add(u);
            mDb.Configuration.ValidateOnSaveEnabled = false;
            mDb.SaveChanges();
        }
    }
}