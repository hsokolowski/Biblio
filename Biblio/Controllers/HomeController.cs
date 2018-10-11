using Biblio.Models;
using Biblio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Biblio.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult LastAdded()
        {
            MovieAdd ma = new MovieAdd();
            List<Movie> lista = ma.GetMovie();
            return View(lista);
        }
        public ActionResult ListaFilmów()
        {
            MovieAdd ma = new MovieAdd();
            List<Movie> lista = ma.GetMovie();
            return View(lista);
        }
        // po zalogowaniu
        [Authorize]
        public ActionResult ListaAdminow()
        {
            AdminAdd vm = new AdminAdd();
            List<Admin> lista = vm.GetAdmins();
            return View(lista);
        }
        [Authorize]
        public ActionResult Favourite2(int id, int whu)
        {
            GlobalModels gm = new GlobalModels();
            FavAddVM vm = new FavAddVM();
            MovieAdd vm2 = new MovieAdd();
            //List<Favourite> list = vm.GetFava();
            gm.Ulubs= vm.GetFava();
            gm.Films = vm2.GetMovie();
            Favourite tym = gm.Ulubs.SingleOrDefault(m => m.who == whu && m.which == id);
            //Favourite tym = list.SingleOrDefault(m => m.who == whu && m.which == id);
            if (tym == null)
            {
                vm.UlubDodaj(id,whu);
                //list = vm.GetFava();
                gm.Ulubs = vm.GetFava();
                gm.Films = vm2.GetMovie();
                return View("Favourite", gm);
            }
            else 
            {
                TempData["Message"] = "Ten film jest już w Ulubionych!";
                TempData["ID_z_ulub"] = id;
                return RedirectToAction("ListaFilmów");
                //jest w bazie
            }
        }
        [Authorize]
        public ActionResult Favourite()
        {
            FavAddVM vm = new FavAddVM();
            MovieAdd vm2 = new MovieAdd();
            //List<Favourite> list = vm.GetFava();
            GlobalModels gm = new GlobalModels();
            gm.Films = vm2.GetMovie();
            gm.Ulubs = vm.GetFava();
            return View(gm);
        }
        public ActionResult DeleteFav(int id)
        {
            FavDELETEvm vm = new FavDELETEvm();
            vm.DeleteFav(id);
            return RedirectToAction("Favourite");
        }
        public ActionResult Details(int id)
        {
            MovieDETAILSvm vm = new MovieDETAILSvm();
            Movie u = vm.FindMovie(id);
            return View(u);
        }
        public ActionResult Delete(int id)
        {
            MovieDELETEvm vm = new MovieDELETEvm();
            vm.DeleteMovie(id);
            return RedirectToAction("ListaFilmów");
        }
        //public ActionResult Delete(int id)
        //{
        //    Session["IDdoKasacji"] = id;
        //    return View("Delete",id); ;
        //}
        //public ActionResult Delete2(int id)
        //{
        //    MovieDELETEvm vm = new MovieDELETEvm();
        //    vm.DeleteMovie(id);
        //    return RedirectToAction("Delete");
        //}

        [Authorize]
        public ActionResult Edit(int id)
        {
            MovieEDITvm vm = new MovieEDITvm();
            List<Movie> lista = vm.GetMovie();
            Movie movie = lista.Where(s => s.movieID == id).FirstOrDefault();
            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie m)
        {
            MovieEDITvm vm = new MovieEDITvm();
            vm.Update(m);
            ViewBag.Succesmessage = "Edycja pomyślna!";
            return RedirectToAction("ListaFilmów");
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movie u)
        {
            MovieAdd userBL = new MovieAdd();
            Movie o = new Movie();
            o = u;
            userBL.AddUser(o);
            return RedirectToAction("ListaFilmów");
        }
        [HttpGet]
        public ActionResult AdminAdd(int id=0 )
        {
            Admin a = new Admin();
            return View(a);
        }
        [HttpPost]
        public ActionResult AdminAdd(Admin b)
        {
            Admin a = new Admin();
            AdminAdd ad = new ViewModels.AdminAdd();
            a = b;
            List<Admin> list = ad.GetAdmins();
            if (list.Any(x => x.login == b.login))
            {
                ViewBag.DuplicateMessage = "Taka nazwa już istnieje!";
                return View("AdminAdd",b);
            }
            a.password = Encrypt.GetHash(a.password);
            ad.AddUser(a);
            ViewBag.Succesmessage = "Rejestracja pomyślna!";
            return View("AdminAdd", new Admin());
        }
        [HttpPost]        
        [AllowAnonymous]
        public ActionResult Login(Admin user,string ReturnUrl)  //Autoryzacja Logownie
        {
            var url = ViewBag.ReturnUrl;
            AuthorizationVM avm = new AuthorizationVM();
            using (DAL.DB db = new DAL.DB())
            {
                var tym = Encrypt.GetHash(user.password);
                var userdeatils = db.Admini.Where(x => x.login == user.login && x.password == tym).FirstOrDefault();
                if(userdeatils==null)
                {
                    ViewBag.LoginErrorMessage = "Nie poprawny login lub hasło";
                    return View("Login",user);
                }
                else
                {
                    Session["adminID"] = userdeatils.adminID;
                    Session["login"] = userdeatils.login;
                    FormsAuthentication.SetAuthCookie(user.login, false);
                    //return Redirect(ReturnUrl);
                    
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                   
                }
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        public ActionResult Logout()
        {
            int userid = (int)Session["adminID"];
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Home");
        }

    }
}