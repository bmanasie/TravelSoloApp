using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelSoloApp.Models;

namespace TravelSoloApp.Controllers
{

    [RequireHttps]
    public class HomeController : Controller
    {
        private Model1Container db = new Model1Container();
        public ActionResult Index()
        {
            return View();
        }

        //Exceution of dynamic charts
        public ActionResult About()
        {
            try
            {
               

                ViewBag.DataPoints = JsonConvert.SerializeObject(db.Points1.ToList(), _jsonSetting);

                return View();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                return View("Error");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return View("Error");
            }
        }
         
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //View all the upcoming trips
        public ActionResult ViewTrips()
        {
            var upcomingTrips = db.Trips.Where(g => g.Date> DateTime.Now);
            return View(upcomingTrips);
        }
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };


       
         

    }
}