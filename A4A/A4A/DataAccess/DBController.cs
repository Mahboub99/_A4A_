using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using A4A.Models;


namespace A4A.DataAccess
{
    public class DBController
    {
        DBManager dbMan;
        public DBController()
        {
            dbMan = new DBManager();
        }


        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

        public int InsertUser(AccountModel AM)
        {
            string StoredProcedureName = StoredProcedures.Insert_User;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@UserID", AM.ID);
            Parameters.Add("@Fname", AM.Fname);
            Parameters.Add("@Lname", AM.Lname);
            Parameters.Add("@Email", AM.Email);
            Parameters.Add("@Rating", AM.Rating);
            Parameters.Add("@Password", AM.Password);
            Parameters.Add("@Type", AM.Type);

            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public int InsertGroup(GroupModel GM)
        {
            string StoredProcedureName = StoredProcedures.InsertGroup;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@GroupID", GM.GroupID);
            Parameters.Add("@GroupName", GM.GroupName);
            Parameters.Add("@AdminID", GM.AdminID);

            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int InsertContest(ContestModel CM)
        {
            string StoredProcedureName = StoredProcedures.InsertContest;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ContestID", CM.ContestID);
            Parameters.Add("@ContestName", CM.ContestName);
            Parameters.Add("@ContestDate", CM.ContestDate);
            Parameters.Add("@ContestLength", CM.ContestLength);
            Parameters.Add("@ContestWriterID", CM.ContestWriterID);

            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int Count_Users()
        {
            string StoredProcedureName = StoredProcedures.Count_Users;
            return Convert.ToInt32(dbMan.ExecuteScalar(StoredProcedureName, null));
        }
        public int CountGroups()
        {
            string StoredProcedureName = StoredProcedures.CountGroups;
            return Convert.ToInt32(dbMan.ExecuteScalar(StoredProcedureName, null));
        }

        public int Select_User_ID(string Email, string Password)
        {
            string StoredProcedureName = StoredProcedures.Check_Email_And_Password;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Email", Email);
            Parameters.Add("@Password", Password);

            return Convert.ToInt32(dbMan.ExecuteScalar(StoredProcedureName, Parameters));
        }
        public DataTable SelectProblems()
        {
            string StoredProcedureName = StoredProcedures.LoadProblems;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable SelectContests()
        {
            string StoredProcedureName = StoredProcedures.LoadContests;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public int InsertSubmission(SubmissionModel SM)
        {
            string StoredProcedureName = StoredProcedures.InsertSubmission;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@SubmissionID", SM.SubmissionID);
            Parameters.Add("@ContestantID", SM.ContestantID);
            Parameters.Add("@SubmissionVerdict", SM.SubmissionVerdict);
            Parameters.Add("@SubmissionMemory", SM.SubmissionMemory);
            Parameters.Add("@SubmissionTime", SM.SubmissionTime);
            Parameters.Add("@SubmissionDate", SM.SubmissionDate);
            Parameters.Add("@SubmissionLang", SM.SubmissionLang);
            Parameters.Add("@ProblemID", SM.ProblemID);


            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }


        public DataTable SelectUsers()
        {
            string StoredProcedureName = StoredProcedures.ViewAllUsers;
            return dbMan.ExecuteReader(StoredProcedureName, null);

        }

        public DataTable SelectProblems()
        {
            string StoredProcedureName = StoredProcedures.LoadProblems;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }

        public DataTable SelectContests()
        {
            string StoredProcedureName = StoredProcedures.LoadContests;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }

        public DataTable SelectMyContests(int UserID)
        {
            string StoredProcedureName = StoredProcedures.LoadMyContests;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@UserID", UserID);

            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public DataTable SelectContestProblems(int ContestID)
        {
            string StoredProcedureName = StoredProcedures.SelectContestProblems;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ContestID", ContestID);

            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable GetSubmissionByID(int SubmissionID)
        {
            string StoredProcedureName = StoredProcedures.GetSubmissionByID;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@SubmissionID", SubmissionID);

            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public DataTable SelectUserNameByID(int id)
        {
            string StoredProcedureName = StoredProcedures.SelectUserNameByID;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@UserID", id);

            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public string GetProblemNameByID(string ProblemID)
        {
            string StoredProcedureName = StoredProcedures.GetProblemNameByID;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ProblemID", ProblemID);

            return Convert.ToString(dbMan.ExecuteScalar(StoredProcedureName, Parameters));
        }

        public DataTable SelectUsers()
        {
            string StoredProcedureName = StoredProcedures.ViewAllUsers;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable SelectUser(int id)
        {
            string StoredProcedureName = StoredProcedures.Select_User;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@UserID", id);

            return dbMan.ExecuteReader(StoredProcedureName, Parameters);

        }
        public DataTable SelectAllGroups()
        {
            string StoredProcedureName = StoredProcedures.LoadGroups;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable SelectMyGroups(int ID)
        {
            string StoredProcedureName = StoredProcedures.LoadGroupsOfUser;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@AdminID", ID);

            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
    }
}
