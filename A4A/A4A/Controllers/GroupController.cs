using A4A.DataAccess;
using A4A.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A4A.Controllers
{
    public class GroupController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("ViewAllGroups");
        }
        public ActionResult CreateGroup()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGroup(GroupModel GM)
        {
            DBController db = new DBController();

            GM.GroupID = db.CountGroups() + 1;
            //TODO Add Admin ID


            db.InsertGroup(GM);
            return View();
        }
        public ActionResult ViewAllGroups()
        {
            DBController dbController = new DBController();
            DataTable dt = dbController.SelectAllGroups();

            List<GroupModel> Groups = new List<GroupModel>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                GroupModel group = new GroupModel();
                group.GroupName = Convert.ToString(dt.Rows[i]["GroupName"]);
                group.GroupID = int.Parse(Convert.ToString(dt.Rows[i]["GroupId"]));
                group.AdminID = int.Parse(Convert.ToString(dt.Rows[i]["GroupAdmin"]));
                
                Groups.Add(group);
            }
            return View(Groups);
        }
        public ActionResult ViewMyGroups(int UserID)
        {
            DBController dbController = new DBController();
            DataTable dt = dbController.SelectMyGroups(UserID);
            List<GroupModel> MyGroups = new List<GroupModel>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                GroupModel group = new GroupModel();
                group.GroupName = Convert.ToString(dt.Rows[i]["GroupName"]);
                group.GroupID = int.Parse(Convert.ToString(dt.Rows[i]["GroupId"]));
                group.AdminID = int.Parse(Convert.ToString(dt.Rows[i]["GroupAdmin"]));
                MyGroups.Add(group);
            }
            return View(MyGroups);
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
        public ActionResult GroupOptions()
        {
            return View();
        }      
        public ActionResult SuccessfulCreationOfGroup()
        {
            return View();
        }
    }
}
