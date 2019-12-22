using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using A4A.DataAccess;
using A4A.Models;

namespace A4A.Controllers
{
    public class ContestController : Controller
    {
        [Route("Contest/ViewContest")]
        public ActionResult ViewContests(int id = 0, string UserName = "")
        {
            DBController dbController = new DBController();
            DataTable dt = dbController.SelectContests();
            List<ContestModel> list = new List<ContestModel>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            { 
                Models.ContestModel Contest = new ContestModel();
                Contest.ContestID = Convert.ToInt16(dt.Rows[i]["ContestID"]);
                Contest.ContestName = Convert.ToString(dt.Rows[i]["ContestName"]);
                Contest.ContestDate = Convert.ToDateTime(dt.Rows[i]["ContestDate"]);
                Contest.ContestLength = int.Parse(Convert.ToString(dt.Rows[i]["ContestLength"]));

                Contest.ContestWriterID = int.Parse(Convert.ToString(dt.Rows[i]["ContestWriter"]));
                DataTable WriterName = dbController.SelectUserNameByID(Contest.ContestWriterID);
                Contest.ContestWriterName = Convert.ToString(WriterName.Rows[0]["Fname"]) + " " +
                                            Convert.ToString(WriterName.Rows[0]["Lname"]);

                list.Add(Contest);
            }

            
            ViewBag.ID = id;
            ViewBag.UserName = UserName;
            return View(list);
        }

        public ActionResult ViewMyContests(int id = 0, string UserName = "") 
        {
            DBController dbController = new DBController();
            DataTable dt = dbController.SelectMyContests(id);
            List<ContestModel> list = new List<ContestModel>();
            if (dt == null)
            {
                return RedirectToAction("EmptyContests");
            }
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                Models.ContestModel Contest = new ContestModel();
                Contest.ContestID = Convert.ToInt16(dt.Rows[i]["ContestID"]);
                Contest.ContestName = Convert.ToString(dt.Rows[i]["ContestName"]);
                Contest.ContestDate = Convert.ToDateTime(dt.Rows[i]["ContestDate"]);
                Contest.ContestLength = int.Parse(Convert.ToString(dt.Rows[i]["ContestLength"]));

                Contest.ContestWriterID = int.Parse(Convert.ToString(dt.Rows[i]["ContestWriter"]));
                DataTable WriterName = dbController.SelectUserNameByID(Contest.ContestWriterID);
                Contest.ContestWriterName = Convert.ToString(WriterName.Rows[0]["Fname"]) + " " +
                                            Convert.ToString(WriterName.Rows[0]["Lname"]);

                list.Add(Contest);
            }

            ViewBag.id = id;
            ViewBag.UserName = UserName;
            return View(list);
        }

        public ActionResult ContestProblems(int ContestID)
        {
            DBController dbController = new DBController();
            DataTable dt = dbController.SelectContestProblems(ContestID);
            List<ProblemModel> list = new List<ProblemModel>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                ProblemModel problem = new ProblemModel();
                problem.ProblemName = Convert.ToString(dt.Rows[i]["ProblemName"]);
                problem.ProblemTopic = Convert.ToString(dt.Rows[i]["ProblemTopic"]);
                problem.ProblemLink = Convert.ToString(dt.Rows[i]["ProblemLink"]);
                problem.ProblemDifficulty = int.Parse(Convert.ToString(dt.Rows[i]["ProblemDifficulty"]));
                list.Add(problem);
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult InsertContest(ContestModel CM)
        {
            DBController dbController = new DBController();
            int InsertionVerdict = dbController.InsertContest(CM);
            return View();
        }

        public ActionResult InsertContest(int id, string UserName)
        {
            ViewBag.id = id;
            ViewBag.UserName = UserName;
            return View();

        }

        public ActionResult EmptyContests()
        {
            return View();
        }
    }
}