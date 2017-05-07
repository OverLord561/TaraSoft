using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiplomWebApp;

namespace DiplomWebApp.Controllers
{
    public class OwnersController : Controller
    {
        private MyDBEntities db = new MyDBEntities();

        // GET: Owners
        public ActionResult Index()
        {
            var owners = db.Owners.Include(o => o.Firms);
            return View(owners.ToList());
        }

        [HttpPost]
        public ActionResult Index(string name, string telephone, string number)
        {

            var owners = db.Owners.Include(o => o.Firms).ToList();
            var _name = name != "" ? owners.Where(x => x.Owner.ToUpper().Contains(name.ToUpper())) : owners;
            var _tel = telephone != "" ? owners.Where(x => x.PhoneNumber.ToUpper().Contains(telephone.ToUpper())) : owners;
            var _number = number != "" ? owners.Where(x => x.PostNumber.ToUpper().Contains(number.ToUpper())) : owners;

            var res = _name.Intersect(_tel).Intersect(_number);

            return View(res.ToList());
        }



        // GET: Owners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owners owners = db.Owners.Find(id);
            if (owners == null)
            {
                return HttpNotFound();
            }
            return View(owners);
        }

        // GET: Owners/Create
        public ActionResult Create()
        {
            ViewBag.FirmID = new SelectList(db.Firms, "Id", "NameFirm");
            return View();
        }

        // POST: Owners/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirmID,Owner,PostNumber,PhoneNumber")] Owners owners)
        {
            if (ModelState.IsValid)
            {
                db.Owners.Add(owners);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FirmID = new SelectList(db.Firms, "Id", "NameFirm", owners.FirmID);
            return View(owners);
        }

        // GET: Owners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owners owners = db.Owners.Find(id);
            if (owners == null)
            {
                return HttpNotFound();
            }
            ViewBag.FirmID = new SelectList(db.Firms, "Id", "NameFirm", owners.FirmID);
            return View(owners);
        }

        // POST: Owners/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirmID,Owner,PostNumber,PhoneNumber")] Owners owners)
        {
            if (ModelState.IsValid)
            {
                db.Entry(owners).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FirmID = new SelectList(db.Firms, "Id", "NameFirm", owners.FirmID);
            return View(owners);
        }

        // GET: Owners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owners owners = db.Owners.Find(id);
            if (owners == null)
            {
                return HttpNotFound();
            }
            return View(owners);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Owners owners = db.Owners.Find(id);
            db.Owners.Remove(owners);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
