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

        public string GetProblemNameByID(string ProblemID)
        {
            string StoredProcedureName = StoredProcedures.GetProblemNameByID;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ProblemID", ProblemID);

            return Convert.ToString(dbMan.ExecuteScalar(StoredProcedureName, Parameters));
        }

        public DataTable GetUserNameByID(int id)
        {
            string StoredProcedureName = StoredProcedures.GetUserNameByID;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@UserID", id);

            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
    }
}
