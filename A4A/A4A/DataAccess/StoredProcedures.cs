using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4A.DataAccess
{
    class StoredProcedures
    {
        public static string LoadProblems = "selectAllOfProblems";
        public static string LoadContests = "SelectAllOfContests";
        public static string GetUserNameByID = "SelectUserNameByID";
        public static string InsertContest = "insertContest";
        public static string InsertContestProblem = "InsertContestProblem";
        public static string SelectContestProblems = "SelectContestProblems";
        public static string LoadMyContests = "LoadMyContests";
        public static string InsertSubmission = "InsertSubmission";
        public static string GetSubmissionByID = "GetSubmissionByID";
        public static string GetProblemNameByID = "GetProblemNameByID";
    }
}
