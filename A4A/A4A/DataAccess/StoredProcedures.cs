using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4A.DataAccess
{
    class StoredProcedures
    {
        public static string SelectUserNameByID = "SelectUserNameByID";
        public static string ViewAllUsers = "Select_All_Users";
        public static string Select_User_By_ID = "Select_User_By_ID";
        public static string InsertFriends = "InsertFriends";
        public static string Insert_User = "Insert_User";
        public static string Count_Users = "Count_Users";
        public static string Check_Email_And_Password = "Check_Email_And_Password";
        public static string InsertTeamMembers = "InsertTeamMembers";

        public static string LoadProblems = "selectAllOfProblems";

        public static string InsertContest = "insertContest";
        public static string LoadContests = "SelectAllOfContests";
        public static string InsertContestProblem = "InsertContestProblem";
        public static string SelectContestProblems = "SelectContestProblems";
        public static string LoadMyContests = "LoadMyContests";

        public static string LoadGroups = "SelectAllOfGroups"; 
        public static string LoadGroupsOfUser = "SelectAllOfGroupsOfUser";
        public static string InsertGroup = "InsertGroup";
        public static string CountGroups = "CountGroups";
        public static string InsertGroupMembers = "InsertGroupMembers";
        public static string InsertOrgGroups = "InsertOrgGroups";

        public static string InsertSubmission = "InsertSubmission";
        public static string GetSubmissionByID = "GetSubmissionByID";
        public static string GetProblemNameByID = "GetProblemNameByID";
    }
}
