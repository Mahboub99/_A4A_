using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A4A.Models
{
    public class ContestModel
    {
        public int  ContestID { get; set; }
        public string ContestName { get; set; }
        public DateTime ContestDate { get; set; }
        public int ContestLength { get; set; }
        public int ContestWriterID { get; set; }
        public string ContestWriterName { get; set; }
    }
}