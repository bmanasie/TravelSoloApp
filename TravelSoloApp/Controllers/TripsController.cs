using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TravelSoloApp.Models;

namespace TravelSoloApp.Controllers
{
    [Authorize(Roles = "TripCrafter")]
    public class TripsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Trips
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userList = db.Trips.Where(s => s.TripCrafterId ==
            userId).ToList();
            return View(userList);
        }

        // GET: Trips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = db.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // GET: Trips/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         [ValidateInput(false)]
         [Authorize]
        public ActionResult Create([Bind(Include = "Id,Destination,Description,Date,TripCrafterId,Category,TripCrafterName")] Trip trip)
        {
            StringBuilder desc = new StringBuilder();
            desc.Append(HttpUtility.HtmlEncode(trip.Description));


            trip.Description = desc.ToString();
            trip.TripCrafterId = User.Identity.GetUserId();
            trip.TripCrafterName = User.Identity.GetUserName();

            if (ModelState.IsValid)
            {
                db.Trips.Add(trip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trip);
        }

        // GET: Trips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = db.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Destination,Description,Date,TripCrafterId,Category,TripCrafterName")] Trip trip)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var bookings = db.Bookings.Where(d => d.TripId == trip.Id).SingleOrDefault();
                    if (bookings != null)
                    {

                        ViewBag.Result = "Booking exists in the trip so cannot be edited";
                        return View(trip);
                    }
                    trip.TripCrafterId = User.Identity.GetUserId();
                    trip.TripCrafterName = User.Identity.GetUserName();
                    db.Entry(trip).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException) {

                return View(trip);
            }
            return View(trip);
        }

        // GET: Trips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = db.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {


            Trip trip = db.Trips.Find(id);

            var bookings = db.Bookings.Where(d => d.TripId == id).SingleOrDefault();
            if (bookings != null)
            {

                ViewBag.Result = "Booking exists in the trip so cannot be deleted";
                return View(trip);
            }
            else
            {

                
                db.Trips.Remove(trip);
                db.SaveChanges();
            }
            
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
