﻿using System;
using System.Collections.Generic;
using A4A.DataAccess;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using A4A.Models;
using System.IO;
using System.Data.SqlClient;

namespace A4A.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string UserName, int id = 0)
        {
            ViewBag.ID = id;
            ViewBag.UserName = UserName;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ProblemSet()
        {
            DBController dbController = new DBController();
            DataTable dt = dbController.SelectProblems();
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
    }
}