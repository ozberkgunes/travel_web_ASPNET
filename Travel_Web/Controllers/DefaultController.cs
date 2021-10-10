using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travel_web.Models.DAL;
namespace travel_web.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Contex c = new Contex();
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        public PartialViewResult partialIndex()
        {
            var bloglar = c.Blogs.Take(3).ToList();
            return PartialView(bloglar);
        }
        
    }
}