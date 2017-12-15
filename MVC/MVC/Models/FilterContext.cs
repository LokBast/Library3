using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models
{
    public class FilterContext
    {
        
        public IEnumerable<Book> Books { get; set; }
        public SelectList BookIds { get; set; }
        public SelectList Authors { get; set; }
        
    }
}