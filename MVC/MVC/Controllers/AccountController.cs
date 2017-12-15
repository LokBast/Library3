using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC.Models;

namespace LibraryApp.Controllers

{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogOn model)
        {
            //LibraryEntities db = new LibraryEntities();
            if (ModelState.IsValid)
            {
                // ищем пользователя в базе данных
                User user = null;
                using (OurDbContext db = new OurDbContext())
                {
                    user = db.User.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(Reg)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (LibraryEntities db = new LibraryEntities())
                {
                    user = db.User.FirstOrDefault(u => u.Email == db.User);
                }
                if (user == null)
                {
                  
                    using (LibraryEntities db = new LibraryEntities())
                    {
                        db.userAccount.Add(new User { Email = db.Email, Password = db.Password, Name = db.UserName });
                        db.SaveChanges();

                        //user = db.userAccount.Where(u => u.Email == db.Email && u.Password == db.Password).FirstOrDefault();
                    }
                    
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(db.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}