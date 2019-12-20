using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using A4A.Models;
using AutoCodeforces;
using Newtonsoft.Json;

namespace A4A.Controllers
{
    public class ProblemController : Controller
    {
        // GET: Problem
        [Route("Problem/ViewProblem")]
        public ActionResult ViewProblem(string ProblemLink)
        {
            ProblemModel Problem = new ProblemModel
            {
                ProblemLink = ProblemLink,
            };
            
            //Automate au = new Automate();
            //ParseSubmission(au.SubmissionJsonFile());
                
            return View(Problem);
        }

        public class ProblemObject
        {
            public int ContestId;
            public char Index;

            public string Name;
            public string Type;
            public double Points;
            public int Rating;
            public string[] Tags;
        }
        public class AuthorObject
        {
            public int ContestId;
            public List<MembersHandle> Members = new List<MembersHandle>();
            public string ParticipateType;
            public bool Ghost;
            public int Room;
            public int StartTimeSeconds;
        }
        public class SubmissionObject
        {
            public int Id;
            public int ContestId;
            public int creationTimeSeconds;
            public int relativeTimeSeconds;
            public ProblemObject Problem;
            public AuthorObject Author;
            public string ProgrammingLanguage;
            public string Verdict;
            public string TestSet;
            public int PassedTestCount;
            public int TimeConsumedMillis;
            public int MemoryConsumedBytes;
        }

        public class MembersHandle
        {
            [JsonProperty(PropertyName = "Handle")]
            public string Handle;
        }

        
        public class SubmissionJsonObject
        {
            [JsonProperty(PropertyName = "status")]
            public string Status;

            [JsonProperty(PropertyName = "result")]
            public List<SubmissionObject> SubmissionList;
        }

        public ActionResult ParseSubmission(string SubmissionJson)
        {
            SubmissionJsonObject SubmissionJsonDes =
                JsonConvert.DeserializeObject<SubmissionJsonObject>(SubmissionJson);
                
            if (SubmissionJsonDes.Status == "OK")
            {
                List<SubmissionModel> SubmissionArr = new List<SubmissionModel>();
                SubmissionJsonDes.SubmissionList.ForEach(s =>
                {
                    SubmissionModel sub = new SubmissionModel()
                    {
                        SubmissionID = s.Id,
                        ContestantID = s.ContestId,
                        Verdict = s.Verdict,
                        SubmissionMemeroy = s.MemoryConsumedBytes,
                        SubmissionTime = s.TimeConsumedMillis,
                        SubmissionDate = s.creationTimeSeconds,
                        SubmissionLang = s.ProgrammingLanguage,
                        ProblemID = string.Format("{0}{1}", s.Problem.ContestId ,s.Problem.Index)
                    };
                    SubmissionArr.Add(sub);
                }
                );
            }
            else
            {
                Console.Write("Request to Submission Json Failed");
            }

            return View();
        }


        [HttpPost]
        public ActionResult Submit(ProblemModel Problem)
        {
            Automate Judge = new Automate();
            Judge.OpenCodeforces(Problem.ProblemCode, "4A"/*Problem.ProblemID*/);
            return View("WriteCode", Problem);
        }
    }
}