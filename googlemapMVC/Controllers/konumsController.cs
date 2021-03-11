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
    public class konumsController : Controller
    {
        private haritaCONTEXT db = new haritaCONTEXT();

        // GET: konums
        public ActionResult Index()
        {
            return View(db.konumlar.ToList());
        }

        // GET: konums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            konum konum = db.konumlar.Find(id);
            if (konum == null)
            {
                return HttpNotFound();
            }
            return View(konum);
        }

        // GET: konums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: konums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,baslik,enlem,boylam,sehir,aciklama")] konum konum)
        {
            if (ModelState.IsValid)
            {
                db.konumlar.Add(konum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(konum);
        }

        // GET: konums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            konum konum = db.konumlar.Find(id);
            if (konum == null)
            {
                return HttpNotFound();
            }
            return View(konum);
        }

        // POST: konums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,baslik,enlem,boylam,sehir,aciklama")] konum konum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(konum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(konum);
        }

        // GET: konums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            konum konum = db.konumlar.Find(id);
            if (konum == null)
            {
                return HttpNotFound();
            }
            return View(konum);
        }

        // POST: konums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            konum konum = db.konumlar.Find(id);
            db.konumlar.Remove(konum);
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
