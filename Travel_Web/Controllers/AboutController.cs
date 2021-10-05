using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travel_web.Models.DAL;
namespace travel_web.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Contex con = new Contex();
        public ActionResult Index()
        {
            var item = con.Hakkimizdas.ToList();
            return View(item);
        }
    }
}