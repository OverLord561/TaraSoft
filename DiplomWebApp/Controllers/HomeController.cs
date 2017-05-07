using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiplomWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (MyDBEntities db = new MyDBEntities())
            {
                var users = db.Owners.ToList();
               
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}