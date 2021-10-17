﻿using System;
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
        public ActionResult Index()
        {
            var bloglar = c.Blogs.ToList();
            return View(bloglar);
        }
        [HttpGet]
        public ActionResult BlogEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BlogEkle(Blog b)
        {
            c.Blogs.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int Id)
        {
            var blog = c.Blogs.Find(Id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogDuzenle(int Id)
        {
            //Düzenlenecek
            return RedirectToAction("Index"); 
        }
    }
}