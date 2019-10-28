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

       //POST request of Bulk email
        [HttpPost]
        public ActionResult Index(BulkEmail model,HttpPostedFileBase fileUploader)
        {
            try
            {
                
                    string fileName = Path.GetFileName(fileUploader.FileName);
                    string pathName = Path.Combine(Server.MapPath("~/Content/Uploads/"), fileName);
                    fileUploader.SaveAs(pathName);
                    String contents = model.Message;
                    EmailSender es = new EmailSender();
                    es.SendBulk(contents, pathName, fileName, model.SelectedEmail);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    
                
            }
            catch{

                ViewBag.Result = "Enter the details";
                
            }
            return Index();
        }

    }
}