﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A4A.Models
{
    public class ProblemModel
    {
        public string ProblemName { get; set; }
        public string ProblemTopic { get; set; }       
        public int ProblemDifficulty { get; set; }
        public string ProblemID { get; set; }
        public string ProblemLink { get; set; }
        public int ProblemContestID { get; set; }
        [AllowHtml]
        public string ProblemCode { get; set; }
    }
}