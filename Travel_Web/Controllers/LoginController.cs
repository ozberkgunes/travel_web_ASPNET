using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travel_web.Models.DAL;
using System.Web.Security;

namespace travel_web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            
            Contex c = new Contex();
            var auth = c.Admins.FirstOrDefault(x => x.KullaniciAdi == username && x.Sifre == password);
            if (auth != null)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                Session["Username"] = auth.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.LoginError = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
            
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}