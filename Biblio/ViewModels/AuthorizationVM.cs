using Biblio.DAL;
using Biblio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblio.ViewModels
{
    public class AuthorizationVM
    {
        public List<Admin> GetAdmins()
        {
            DB mDb = new DB();
            List<Admin> listaDB = mDb.Admini.ToList();
            return listaDB;
        }
    }
}