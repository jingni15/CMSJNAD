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
    public class ContainerShippingSchedulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContainerShippingSchedules
        public ActionResult Index()
        {
            var containerShippingSchedules = db.ContainerShippingSchedules.Include(c => c.ArrivalYardLocation).Include(c => c.Container).Include(c => c.DepartureYardLocation).Include(c => c.Ship);
            return View(containerShippingSchedules.ToList());
        }

        // GET: ContainerShippingSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContainerShippingSchedule containerShippingSchedule = db.ContainerShippingSchedules.Find(id);
            if (containerShippingSchedule == null)
            {
                return HttpNotFound();
            }
            return View(containerShippingSchedule);
        }

        // GET: ContainerShippingSchedules/Create
        public ActionResult Create()
        {
            ViewBag.ArrivalShipyardID = new SelectList(db.YardLocations, "YardLocationID", "YardName");
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerDescription");
            ViewBag.DepartureShipyardID = new SelectList(db.YardLocations, "YardLocationID", "YardName");
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName");
            return View();
        }

        // POST: ContainerShippingSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create([Bind(Include = "ContainerShippingScheduleID,ShipID,ContainerID,DepartureShipyardID,ArrivalShipyardID,DepartureDateTime,ArrivalDateTime,PriceAmount")] ContainerShippingSchedule containerShippingSchedule)
        {
            if (ModelState.IsValid)
            {
                db.ContainerShippingSchedules.Add(containerShippingSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArrivalShipyardID = new SelectList(db.YardLocations, "YardLocationID", "YardName", containerShippingSchedule.ArrivalShipyardID);
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerDescription", containerShippingSchedule.ContainerID);
            ViewBag.DepartureShipyardID = new SelectList(db.YardLocations, "YardLocationID", "YardName", containerShippingSchedule.DepartureShipyardID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", containerShippingSchedule.ShipID);
            return View(containerShippingSchedule);
        }

        // GET: ContainerShippingSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContainerShippingSchedule containerShippingSchedule = db.ContainerShippingSchedules.Find(id);
            if (containerShippingSchedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArrivalShipyardID = new SelectList(db.YardLocations, "YardLocationID", "YardName", containerShippingSchedule.ArrivalShipyardID);
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerDescription", containerShippingSchedule.ContainerID);
            ViewBag.DepartureShipyardID = new SelectList(db.YardLocations, "YardLocationID", "YardName", containerShippingSchedule.DepartureShipyardID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", containerShippingSchedule.ShipID);
            return View(containerShippingSchedule);
        }

        // POST: ContainerShippingSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "ContainerShippingScheduleID,ShipID,ContainerID,DepartureShipyardID,ArrivalShipyardID,DepartureDateTime,ArrivalDateTime,PriceAmount")] ContainerShippingSchedule containerShippingSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(containerShippingSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArrivalShipyardID = new SelectList(db.YardLocations, "YardLocationID", "YardName", containerShippingSchedule.ArrivalShipyardID);
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerDescription", containerShippingSchedule.ContainerID);
            ViewBag.DepartureShipyardID = new SelectList(db.YardLocations, "YardLocationID", "YardName", containerShippingSchedule.DepartureShipyardID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", containerShippingSchedule.ShipID);
            return View(containerShippingSchedule);
        }

        // GET: ContainerShippingSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContainerShippingSchedule containerShippingSchedule = db.ContainerShippingSchedules.Find(id);
            if (containerShippingSchedule == null)
            {
                return HttpNotFound();
            }
            return View(containerShippingSchedule);
        }

        // POST: ContainerShippingSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            ContainerShippingSchedule containerShippingSchedule = db.ContainerShippingSchedules.Find(id);
            db.ContainerShippingSchedules.Remove(containerShippingSchedule);
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
