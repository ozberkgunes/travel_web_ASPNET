using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travel_web.Models.DAL;
namespace travel_web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Contex c = new Contex();
        [Authorize]
        public ActionResult Index()
        {
            var bloglar = c.Blogs.ToList();
            return View(bloglar);
        }
        
        [Authorize, HttpGet]
        public ActionResult BlogEkle()
        {
            return View();
        }
        [Authorize,HttpPost]
        public ActionResult BlogEkle(Blog b)
        {
            c.Blogs.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult BlogSil(int Id)
        {
            var blog = c.Blogs.Find(Id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult BlogDuzenle(int Id)
        {
            var blog = c.Blogs.Find(Id);
            return View("BlogDuzenle", blog); 
        }
        [Authorize, HttpPost]
        public ActionResult BlogDuzenle(Blog b)
        {
            var blog = c.Blogs.Find(b.Id);
            blog.Aciklama = b.Aciklama;
            blog.BlogImage = b.BlogImage;
            blog.Baslik = b.Baslik;
            blog.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }

        [Authorize]
        public ActionResult YorumSil(int id)
        {
            var yorum = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(yorum);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        [Authorize]
        public ActionResult YorumDuzenle(int id)
        {
            var yorumlar = c.Yorumlars.Find(id);
            return View("YorumDuzenle", yorumlar);
        }

        [Authorize, HttpPost]
        public ActionResult YorumDuzenle(Yorumlar y)
        {
            var yorumlar = c.Yorumlars.Find(y.Id);
            yorumlar.KullaniciAdi = y.KullaniciAdi;
            yorumlar.Mail = y.Mail;
            yorumlar.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

    }
}