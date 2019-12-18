using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A4A.Models
{
    public class ProblemModel
    {
        public string ProblemID { get; set; }
        public string ProblemLink { get; set; }
        [AllowHtml]
        public string ProblemCode { get; set; }
    }
}