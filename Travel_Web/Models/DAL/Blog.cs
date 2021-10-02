using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace travel_web.Models.DAL
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string MyProperty { get; set; }


    }
}