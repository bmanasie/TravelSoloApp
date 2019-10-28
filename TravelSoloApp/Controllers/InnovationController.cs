using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelSoloApp.Controllers
{

    //Implementation of Signal R
    public class InnovationController : Controller
    {
        // GET: Innovation
        public ActionResult ChatRoom()
        {
            return View();
        }
    }
}