using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using A4A.Models;
using DataController;

namespace A4A.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

            var Model = DataController.BussinessLogic.ProblemSet.LoadProblems();
            List<ProblemSetModel> list = new List<ProblemSetModel>();
            foreach(var row in Model)
            {
                list.Add(new ProblemSetModel
                {
                    ProblemName = row.ProblemName,
                    ProblemTopic = row.ProblemTopic,
                    ProblemDifficulty = row.ProblemDifficulty
                });
            }
            return View(list);
        }

    }
}