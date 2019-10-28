using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TravelSoloApp.Utils
{
    public class EmailSender
    {

        private const String API_KEY = "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";

        public void Send( String name, String emailid, String contents,String pathName, String fileName )
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", name);
            var to = new EmailAddress("manasie.bajpai@gmail.com");
            var plainTextContent = contents;
            var htmlContent = "<p>"+"Email from "+ "</p>"+emailid+ "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, "Mail from Travel App  "+name, plainTextContent, htmlContent);
            var bytes = File.ReadAllBytes(pathName);
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment(fileName, file);
            var response = client.SendEmailAsync(msg);
        }

        public void SendBulk(String contents, String pathName,String fileName, IList<String> emailIds)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "Admin");
            var tos = new List<EmailAddress>();

            foreach (var item in emailIds)
            {
                tos.Add(new EmailAddress(item));
            }
            var plainTextContent = contents;
            var htmlContent =  "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, "Travel App from Admin", plainTextContent, htmlContent);
            var bytes = File.ReadAllBytes(pathName);
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment(fileName, file);
            var response = client.SendEmailAsync(msg);
        }
    }
}