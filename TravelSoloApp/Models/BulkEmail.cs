using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelSoloApp.Models
{
    public class BulkEmail
    {
        [Required]
        public IList<string> SelectedEmail { get; set; }

        [Required]
        public string Message { get; set; }

        public BulkEmail()
        {
            SelectedEmail = new List<string>();
        }
    }
}