using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;using System.Web.Mvc;

namespace A4A.Models
{
    public class ContestModel
    {
        public int  ContestID { get; set; }
        [Required (ErrorMessage = "This field is required")]
        public string ContestName { get; set; }
        public DateTime ContestDate { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int ContestLength { get; set; }
        public int ContestWriterID { get; set; }
        public string ContestWriterName { get; set; }
        //public IEnumerable<SelectListItem> AvailableProblems { get; set; }
        //public IEnumerable<SelectListItem> Problem1 { get; set; }
        //public IEnumerable<SelectListItem> Problem2 { get; set; }
        //public IEnumerable<SelectListItem> Problem3 { get; set; }
        //public IEnumerable<SelectListItem> Problem4 { get; set; }
        //public IEnumerable<SelectListItem> Problem5 { get; set; }

        public string AvailableProblems { get; set; }
        public string Problem1 { get; set; }
        public string Problem2 { get; set; }
        public string Problem3 { get; set; }
        public string Problem4 { get; set; }
        public string Problem5 { get; set; }

    }
}