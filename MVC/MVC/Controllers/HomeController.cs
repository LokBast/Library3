using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.Data.Entity;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        LibraryEntities db = new LibraryEntities();
        public ActionResult Index(string bookId, string author)
        {/*
            ViewBag.booksId = db.Book;
            //IQueryable<Book> book = db.Book.Include(p => p.BookId);
            if (bookId != null && bookId != "" && booksId.BookID == db.Book)
            {
                ViewBag.Books = book.Where(p => p.BookId == bookId);            
            }

            FilterContext fc = new FilterContext();
            {
                
            }*/

            ViewBag.Books = db.Book;
            return View();
        }


















        public ActionResult Login()
        {
            return View();
        }

        
        //[Authorize (Users = "user")]
        public ActionResult Reserve()
        {
            //ViewBag.Books = db.Book;
            return View();
        }
    }
}