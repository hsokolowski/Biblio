using Biblio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Biblio.Controllers
{
    public class AuthenticationController : Controller
    {
        public static Admin sesjaAdmin
        {
            get
            {
                object o = System.Web.HttpContext.Current.Session["abc"];
                if (o == null)
                {
                    
                }
                return o as Admin;
            }
            set
            {
                System.Web.HttpContext.Current.Session["abc"] = value;
            }
        }
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }
        
    }
       
}