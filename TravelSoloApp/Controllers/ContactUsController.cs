using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelSoloApp.Models;
using TravelSoloApp.Utils;

namespace TravelSoloApp.Controllers
{
    public class ContactUsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: ContactUs
        public ActionResult Index()
        {
            return View(db.ContactUs.ToList());
        }


        // GET: ContactUs/Create
        public ActionResult Create()
        {
            return View(new ContactUs());
        }

        // POST: ContactUs/Create
        // User wishes to send an email 
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
