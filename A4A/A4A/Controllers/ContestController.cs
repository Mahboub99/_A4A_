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
        public ActionResult ViewContests()
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

            return View(list);
        }

        //TODO (the parameters)
        public ActionResult ViewMyContests(int User_ID = 1) 
        {
            DBController dbController = new DBController();
            DataTable dt = dbController.SelectMyContests(User_ID);
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

            return View(list);
        }

        public ActionResult ContestProblems(int ContestID)
        {
            DBController dbController = new DBController();
            DataTable dt = dbController.SelectContestProblems(ContestID);
            List<ProblemSetModel> list = new List<ProblemSetModel>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                ProblemSetModel problem = new ProblemSetModel();
                problem.ProblemName = Convert.ToString(dt.Rows[i]["ProblemName"]);
                problem.ProblemTopic = Convert.ToString(dt.Rows[i]["ProblemTopic"]);
                problem.ProblemLink = Convert.ToString(dt.Rows[i]["ProblemLink"]);
                problem.ProblemDifficulty = int.Parse(Convert.ToString(dt.Rows[i]["ProblemDifficulty"]));
                list.Add(problem);
            }

            return View(list);
        }

        //TODO (wait for Mahboub)
        public ActionResult InsertContest(ContestModel CM)
        {
            DBController dbController = new DBController();
            int InsertionVerdict = dbController.InsertContest(CM);
            return View();
        }
    }
}