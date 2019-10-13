using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelSoloApp.Models;

namespace TravelSoloApp.Controllers
{
    public class BookingFeedbacksController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: BookingFeedbacks
        public ActionResult Index()
        {
            return View(db.BookingFeedbacks.ToList());
        }

        public ActionResult setRating(string bookingid, short rating) {

            BookingFeedback bookingfeedback = new BookingFeedback();
            bookingfeedback.Rating = rating;
            bookingfeedback.BookingId = bookingid;

            db.BookingFeedbacks.Add(bookingfeedback);
            db.SaveChanges();

            return RedirectToAction("Index", "Bookings", new { id = bookingid });
        }




        // GET: BookingFeedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingFeedback bookingFeedback = db.BookingFeedbacks.Find(id);
            if (bookingFeedback == null)
            {
                return HttpNotFound();
            }
            return View(bookingFeedback);
        }

        // GET: BookingFeedbacks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingFeedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rating,BookingId")] BookingFeedback bookingFeedback)
        {
            if (ModelState.IsValid)
            {
                db.BookingFeedbacks.Add(bookingFeedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookingFeedback);
        }

        // GET: BookingFeedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingFeedback bookingFeedback = db.BookingFeedbacks.Find(id);
            if (bookingFeedback == null)
            {
                return HttpNotFound();
            }
            return View(bookingFeedback);
        }

        // POST: BookingFeedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rating,BookingId")] BookingFeedback bookingFeedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingFeedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingFeedback);
        }

        // GET: BookingFeedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingFeedback bookingFeedback = db.BookingFeedbacks.Find(id);
            if (bookingFeedback == null)
            {
                return HttpNotFound();
            }
            return View(bookingFeedback);
        }

        // POST: BookingFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingFeedback bookingFeedback = db.BookingFeedbacks.Find(id);
            db.BookingFeedbacks.Remove(bookingFeedback);
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
