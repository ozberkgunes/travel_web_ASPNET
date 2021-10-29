using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travel_web.Models.DAL;
namespace travel_web.Controllers
{
    public class BlogController : Controller
    {
        Contex con = new Contex();
        BlogYorum by = new BlogYorum();
        // GET: Blog
        public ActionResult Index()
        {
            by.Blog = con.Blogs.ToList();
            by.BlogSayi = con.Blogs.Take(3).ToList();
            by.YorumSayisi = con.Yorumlars.Take(3).ToList();
            //var bloglar = con.Blogs.ToList();
            return View(by);
        }

        public ActionResult BlogDetay(int Id)
        {
            //var findBlog = con.Blogs.Where(x => x.Id == Id).ToList();
            by.Blog = con.Blogs.Where(x => x.Id == Id).ToList();
            by.Yorum = con.Yorumlars.Where(x => x.BlogId == Id).ToList();
            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            con.Yorumlars.Add(y);
            con.SaveChanges();
            return PartialView();
        }

    }
}