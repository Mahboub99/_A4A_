using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A4A.Models
{
    public class TeamModel
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public int Rating { get; set; }
        public int LeaderID { get; set; }
        public string Member2 { get; set; }
        public string Member3 { get; set; }
    }
}