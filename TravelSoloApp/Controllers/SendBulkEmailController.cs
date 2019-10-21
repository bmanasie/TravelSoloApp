using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelSoloApp.Models;
using TravelSoloApp.Utils;

namespace TravelSoloApp.Controllers
{
    public class SendBulkEmailController : Controller
    {
        private Model1Container db = new Model1Container();
        // GET: SendBulkEmail
        public ActionResult Index()
        {
            var allusers = db.AspNetUsers.Where(s => s.UserRole == "User").ToList();
            return View(allusers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,UserEmailId,Message")] ContactUs contactUs, HttpPostedFileBase fileUploader)
        {

            try
            {
                String fromEmail = contactUs.UserEmailId;
                String name = contactUs.Name;

                String contents = contactUs.Message;

                string fileName = Path.GetFileName(fileUploader.FileName);
                string pathName = Path.Combine(Server.MapPath("~/Content/Uploads/"), fileName);
                fileUploader.SaveAs(pathName);
                EmailSender es = new EmailSender();
                es.Send(fromEmail, name, contents, pathName, fileName);

                ViewBag.Result = "Email has been send.";

                ModelState.Clear();

                return View(new ContactUs());
            }
            catch
            {
                return View();
            }


        }



        [HttpPost]
        public ActionResult Index(BulkEmail model)
        {
            if (ModelState.IsValid)
            {
                var emailIds = string.Join(";", model.SelectedEmail);

                // Save data to database, and redirect to Success page.

                return RedirectToAction("Success");
            }
           
            return View(model);
        }

    }
}