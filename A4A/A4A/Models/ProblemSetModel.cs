using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A4A.Models
{
    public class ProblemSetModel
    {
        public string ProblemName { get; set; }
        public string ProblemTopic { get; set; }
        public string ProblemLink { get; set; }
        public int ProblemDifficulty { get; set; }
    }
}