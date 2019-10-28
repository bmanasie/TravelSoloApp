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


        // GET: BookingFeedbacks/Create
        // Method call when the user lands on booking feedback page
        public ActionResult Create(int id)
        {
            BookingFeedback bookingFeedback = new BookingFeedback();
            bookingFeedback.Booking_Id = id;


            return View(bookingFeedback);
        }

        // POST: BookingFeedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(short Rating, int Booking_Id)
        {
            var bookingFeedback = new BookingFeedback() ;

            Booking booking = db.Bookings.Find(Booking_Id);
            if (ModelState.IsValid)
            {
                bookingFeedback.Booking_Id = Booking_Id;
                bookingFeedback.Rating = Rating;
        
                bookingFeedback.Booking = booking;
                db.BookingFeedbacks.Add(bookingFeedback);
                db.SaveChanges();
                return RedirectToAction("Index", "Bookings");
            }

            return View(bookingFeedback);
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
