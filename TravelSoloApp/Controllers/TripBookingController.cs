using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelSoloApp.Models;

namespace TravelSoloApp.Controllers
{
    public class BookingDto
    { 
    
    public int tripid { get; set; }
    }


    [Authorize]
    public class TripBookingController : ApiController
    {
        private Model1Container _context;
        public TripBookingController()
        {
            _context = new Model1Container();
        }
        [HttpPost]
        public IHttpActionResult Book(BookingDto dto)
        {
            var userId = User.Identity.GetUserId();

            var exists = _context.Bookings.Any(a => a.AspNetUserId == userId && a.TripId == dto.tripid);
            if (exists)
                return BadRequest("Booking already made");
            var booking = new Booking()
            {
                TripId = dto.tripid,
                AspNetUserId = userId,
                BookingDate = System.DateTime.Now

            };
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return Ok();
        }



    }
}