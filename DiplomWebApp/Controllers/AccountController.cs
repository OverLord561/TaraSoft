using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiplomWebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string password)
        {
            if (name == "admin" && password == "admin")
            {
                TempData["Login"] = "admin";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Помилка при вході!";
                return View();
            }

            
        }
    }
}