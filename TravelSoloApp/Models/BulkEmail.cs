using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelSoloApp.Models
{
    public class BulkEmail
    {
        public IList<string> SelectedEmail { get; set; }
        public IList<SelectListItem> AvaiableEmail { get; set; }

        public BulkEmail()
        {
            SelectedEmail = new List<string>();
            AvaiableEmail = new List<SelectListItem>();
        }
    }
}