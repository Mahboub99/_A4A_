using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using A4A.DataAccess;
using A4A.Models;
using Microsoft.Ajax.Utilities;
using OpenQA.Selenium.Internal;

namespace A4A.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult ViewAllUsers()
        {
            DBController dbController = new DBController();
            DataTable dt = dbController.SelectUsers();

            List<UsersModel> list = new List<UsersModel>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                UsersModel User = new UsersModel();

                User.Name = Convert.ToString(dt.Rows[i]["Fname"]) + " " + Convert.ToString(dt.Rows[i]["Lname"]);

                User.ID = int.Parse(Convert.ToString(dt.Rows[i]["UserID"]));
                User.Rating = int.Parse(Convert.ToString(dt.Rows[i]["Rating"]));
                list.Add(User);
            }
            return View(list);
        }
        public ActionResult ViewUser(int ID)
        {
            DBController dbController = new DBController();
            DataTable dt = dbController.SelectUser(ID);
            AccountModel User = new AccountModel();

            User.Fname = Convert.ToString(dt.Rows[0]["Fname"]);
            User.Lname = Convert.ToString(dt.Rows[0]["Lname"]);
            User.Email = Convert.ToString(dt.Rows[0]["Email"]);
            User.Rating = int.Parse(Convert.ToString(dt.Rows[0]["Rating"]));

            return View(User);
        }

        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(AccountModel accountModel)
        {
            DBController db = new DBController();

            accountModel.ID = db.Count_Users() + 1;
            accountModel.Rating = 0;
            accountModel.Solved = 0;
            accountModel.Binding = 0;
            accountModel.Type = "User";
            db.InsertUser(accountModel);

            return RedirectToAction("ViewAllUsers");
        }

        //[HttpPost]
        //public ActionResult Login(FormCollection form)
        //{
        //    string UserName = form.Get("UserName");
        //    ViewBag.UserName = UserName;
        //    return View();
        //}

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            DBController db = new DBController();
            int id = db.Select_User_ID(Email, Password);

            if (id == 0) // not found
            {
                //TODO uncorrect email or Password
                return View();
            }
            else
            {
                //view of user (home page)
                DataRow dr = db.SelectUserNameByID(id).Rows[0];
                string UserName = Convert.ToString(dr["Fname"]) + Convert.ToString(dr["Lname"]);
                return RedirectToAction("Index", "Home", new { UserName = UserName, id = id });
            }
        }

    }
}