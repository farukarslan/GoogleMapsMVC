using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using googlemapMVC.Models;

namespace googlemapMVC.Controllers
{
    public class sehirsController : Controller
    {
        private haritaCONTEXT db = new haritaCONTEXT();

        // GET: sehirs
        public ActionResult Index()
        {
            return View(db.sehirler.ToList());
        }

        // GET: sehirs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sehir sehir = db.sehirler.Find(id);
            if (sehir == null)
            {
                return HttpNotFound();
            }
            return View(sehir);
        }

        // GET: sehirs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sehirs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,sehiradi")] sehir sehir)
        {
            if (ModelState.IsValid)
            {
                db.sehirler.Add(sehir);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sehir);
        }

        // GET: sehirs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sehir sehir = db.sehirler.Find(id);
            if (sehir == null)
            {
                return HttpNotFound();
            }
            return View(sehir);
        }

        // POST: sehirs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,sehiradi")] sehir sehir)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sehir).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sehir);
        }

        // GET: sehirs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sehir sehir = db.sehirler.Find(id);
            if (sehir == null)
            {
                return HttpNotFound();
            }
            return View(sehir);
        }

        // POST: sehirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sehir sehir = db.sehirler.Find(id);
            db.sehirler.Remove(sehir);
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
