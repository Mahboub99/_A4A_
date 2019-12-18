using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A4A.Models
{
    public class SubmissionModel
    {
        public int SubmissionID { get; set; }
        public int ContestantID { get; set; }
        public string Verdict { get; set; }
        public int SubmissionMemeroy { get; set; }
        public int SubmissionTime { get; set; }
        public int SubmissionDate { get; set; }
        public string SubmissionLang { get; set; }
        public string ProblemID { get; set; }
    }
}