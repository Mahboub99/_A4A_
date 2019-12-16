using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using A4A.Models;

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
                   
                
            return View(Problem);
        }
    }
}