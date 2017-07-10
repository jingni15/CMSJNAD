using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DDACMaerskCMS.Models;

namespace DDACMaerskCMS.Controllers
{
    public class YardLocationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: YardLocations
        public ActionResult Index()
        {
            return View(db.YardLocations.ToList());
        }

        // GET: YardLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YardLocation yardLocation = db.YardLocations.Find(id);
            if (yardLocation == null)
            {
                return HttpNotFound();
            }
            return View(yardLocation);
        }

        // GET: YardLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YardLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create([Bind(Include = "YardLocationID,YardName,LocationName,CountryName")] YardLocation yardLocation)
        {
            if (ModelState.IsValid)
            {
                db.YardLocations.Add(yardLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yardLocation);
        }

        // GET: YardLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YardLocation yardLocation = db.YardLocations.Find(id);
            if (yardLocation == null)
            {
                return HttpNotFound();
            }
            return View(yardLocation);
        }

        // POST: YardLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "YardLocationID,YardName,LocationName,CountryName")] YardLocation yardLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yardLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yardLocation);
        }

        // GET: YardLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YardLocation yardLocation = db.YardLocations.Find(id);
            if (yardLocation == null)
            {
                return HttpNotFound();
            }
            return View(yardLocation);
        }

        // POST: YardLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            YardLocation yardLocation = db.YardLocations.Find(id);
            db.YardLocations.Remove(yardLocation);
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
