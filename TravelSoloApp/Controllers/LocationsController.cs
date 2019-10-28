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
    public class LocationsController : Controller
    {
        private ReachUs db = new ReachUs();

        // GET: Locations
        public ActionResult Index()
        {
           
            return View(db.Locations.ToList());
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
