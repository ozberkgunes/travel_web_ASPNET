using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace travel_web.Models.DAL
{
    public class BlogYorum //view mantığı
    {
        public IEnumerable<Blog> Blog { get; set; }
        public IEnumerable<Yorumlar> Yorum { get; set; }
        public IEnumerable<Blog> BlogSayi { get; set; }
        public IEnumerable<Yorumlar> YorumSayisi { get; set; }
    }
}