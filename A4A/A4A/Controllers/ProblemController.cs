using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

using A4A.DataAccess;
using A4A.Models;
using AutoCodeforces;
using Newtonsoft.Json;
using Helpers;

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

            //Just for Debugging
            //Automate au = new Automate();
            //ParseAndInsertSubmission(au.SubmissionJsonFile());
            //return RedirectToAction("ViewSubmission");


            return View(Problem);
        }

        public ActionResult ParseAndInsertSubmission(string SubmissionJson)
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
                        
                        //TODO (we must get the ContestantID from Our DataBase)
                        ContestantID = 2,

                        SubmissionVerdict = s.Verdict,
                        SubmissionMemory = s.MemoryConsumedBytes,
                        SubmissionTime = s.TimeConsumedMillis,
                        SubmissionDate = UnixTime.ToDateTime(s.creationTimeSeconds),
                        SubmissionLang = s.ProgrammingLanguage,
                        ProblemID = string.Format("{0}{1}", s.Problem.ContestId ,s.Problem.Index)
                    };

                    //SubmissionArr.Add(sub);
                    DBController db = new DBController();
                    db.InsertSubmission(sub);
                }
                );
            }
            else
            {
                Console.Write("Request to Submission Json Failed");
            }

            return View();
        }

        public ActionResult ViewSubmission(int SubmissionID = 52454088 /*Internal ID*/)
        {
            DBController db = new DBController();
            DataTable dt = db.GetSubmissionByID(SubmissionID);

            List<SubmissionModel> list = new List<SubmissionModel>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                SubmissionModel Submission = new SubmissionModel();
                Submission.SubmissionID = Convert.ToInt32(dt.Rows[i]["SubmissionID"]);

                DataTable ContestantName = db.GetUserNameByID(Convert.ToInt32(dt.Rows[i]["ContestantID"]));
                ViewBag.ContestantName = Convert.ToString(ContestantName.Rows[0]["Fname"]) + " " +
                                            Convert.ToString(ContestantName.Rows[0]["Lname"]);


                Submission.SubmissionVerdict = Convert.ToString(dt.Rows[i]["SubmissionVerdict"]);
                Submission.SubmissionMemory = Convert.ToInt32(dt.Rows[i]["SubmissionMemory"]);
                Submission.SubmissionDate = Convert.ToDateTime(dt.Rows[i]["SubmissionDate"]);
                Submission.SubmissionTime = Convert.ToInt32(dt.Rows[i]["SubmissionTime"]);
                Submission.SubmissionLang = Convert.ToString(dt.Rows[i]["SubmissionLang"]);

                Submission.ProblemID = Convert.ToString(dt.Rows[i]["ProblemID"]);
                ViewBag.ProblemName = db.GetProblemNameByID(Submission.ProblemID);

                list.Add(Submission);
            }

            return View(list);
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