using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using DiplomWebApp.Models;

namespace DiplomWebApp.Controllers
{

    public class HomeController : Controller
    {
        public MyDBEntities db = new MyDBEntities();
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


        public JsonResult GetOwners()
        {
            var owners = db.Owners.ToList();
            List<Models.OwnersDTO> res = new List<Models.OwnersDTO>();
            foreach (Owners owner in owners)
            {
                Models.OwnersDTO o = new Models.OwnersDTO { Id = owner.Id, FirmId = owner.FirmId, Name = owner.Owner,Code = owner.PostNumber, Telephone = owner.PhoneNumber };
                res.Add(o);
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetOwners(string firmId)
        {
            int firmid = Convert.ToInt32(firmId);

            var owners = db.Owners.Where(x => x.FirmId == firmid).ToList();
            List<Models.OwnersDTO> res = new List<Models.OwnersDTO>();
            foreach (Owners owner in owners)
            {
                Models.OwnersDTO o = new Models.OwnersDTO { Id = owner.Id, FirmId = owner.FirmId, Name = owner.Owner, Code = owner.PostNumber, Telephone = owner.PhoneNumber };
                res.Add(o);
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFirms()
        {
            var firms = db.Firms.ToList();
            List<Models.FirmsDTO> res = new List<Models.FirmsDTO>();
            foreach (Firms firm in firms)
            {
                Models.FirmsDTO o = new Models.FirmsDTO { Id = firm.Id, Name = firm.NameFirm };
                res.Add(o);
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetFirms(string id)
        {
            int Id = Convert.ToInt32(id);
            Firms firma = db.Firms.FirstOrDefault(x => x.Id == Id);
            return Json(new Models.FirmDetailsDTO {Adress =firma.Address, Code =firma.Code, Phone =firma.Phone}, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult GetOwnerById(string ownerid)
        {
            int Id = Convert.ToInt32(ownerid);
            Owners owner = db.Owners.FirstOrDefault(x => x.Id == Id);


            return Json(new Models.OwnersDTO { Id = owner.Id, FirmId = owner.FirmId, Name = owner.Owner, Code = owner.PostNumber, Telephone = owner.PhoneNumber }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetProducts(string ownerid)
        {
            int ownerID = Convert.ToInt32(ownerid);
            var products = db.Products.Where( x => x.OwnerId == ownerID).ToList();
            List<Models.ProductsDTO> res = new List<Models.ProductsDTO>();
            foreach (Products prod in products)
            {
                Models.ProductsDTO o = new Models.ProductsDTO
                {
                    ProductName = prod.ProductName,
                    Date = prod.Date.ToString(),
                    StartCountry = prod.StartCountry,
                    ProductCode = prod.ProductCode,
                    ProductToll = prod.ProductToll,
                    ProductValue = prod.ProductValue,
                    FinishCountry = prod.FinishCountry,
                    CustomsDecorated_ = prod.CustomsDecorated_,
                    stage = prod.stage
                };
                res.Add(o);
            }
            return Json(res.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}