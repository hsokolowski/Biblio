using Biblio.DAL;
using Biblio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblio.ViewModels
{
    public class AdminAdd
    {
        public List<Admin> GetAdmins()
        {
            DB mDb = new DB();
            List<Admin> listaDB = mDb.Admini.ToList();
            return listaDB;
        }
        public void AddUser(Admin u)
        {
            //DB mDb = new DB();           
            //mDb.Admini.Add(u);
            //mDb.Configuration.ValidateOnSaveEnabled = false;
            //mDb.SaveChanges();
            LayerBus.BusPass.DodajAdmina(u);
        }
    }
}