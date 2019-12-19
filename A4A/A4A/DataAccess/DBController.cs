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

        public DataTable GetUserNameByID(int id)
        {
            string StoredProcedureName = StoredProcedures.GetUserNameByID;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@UserID", id);

            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
    }
}
