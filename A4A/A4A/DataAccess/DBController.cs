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
            string StoredProcedureName = StoredProcedures.Count_Groups;
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
            Parameters.Add("@UserID", ID);

            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public int InsertOrg(OrgModel OM)
        {
            string StoredProcedureName = StoredProcedures.InsertOrg;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@OrgID", OM.OrgID);
            Parameters.Add("@OrgName", OM.OrgName);
            Parameters.Add("@AdminID", OM.AdminID);

            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public DataTable SelectOrgs()
        {
            string StoredProcedureName = StoredProcedures.Select_All_Orgs;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable Select_Orgs_of_Group(int GroupID)
        {
            string StoredProcedureName = StoredProcedures.Select_Orgs_of_Group;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@GroupID", GroupID);

            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public int InsertOrgGroups(int OrgID, int GroupID)
        {
            string StoredProcedureName = StoredProcedures.InsertOrgGroups;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@OrgID", OrgID);
            Parameters.Add("@GroupID", GroupID);

            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int InsertTeam(TeamModel TM)
        {
            string StoredProcedureName = StoredProcedures.InsertTeam;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@TeamID", TM.TeamID);
            Parameters.Add("@TeamName", TM.TeamName);
            Parameters.Add("@LeaderID", TM.LeaderID);
            Parameters.Add("@Rating", 0);

            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public DataTable SelectTeams()
        {
            string StoredProcedureName = StoredProcedures.Select_All_Teams;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable Select_Teams_of_Member(int MemberID)
        {
            string StoredProcedureName = StoredProcedures.Select_Teams_of_Member;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@MemberID", MemberID);

            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public int InsertTeamMembers(int TeamID, int MemberID)
        {
            string StoredProcedureName = StoredProcedures.InsertTeamMembers;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@TeamID", TeamID);
            Parameters.Add("@MemberID", MemberID);

            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int Count_Contests()
        {
            string StoredProcedureName = StoredProcedures.Count_Contests;
            return Convert.ToInt32(dbMan.ExecuteScalar(StoredProcedureName, null));
        }
        public int Count_Orgs()
        {
            string StoredProcedureName = StoredProcedures.Count_Orgs;
            return Convert.ToInt32(dbMan.ExecuteScalar(StoredProcedureName, null));
        }
        public int Count_Teams()
        {
            string StoredProcedureName = StoredProcedures.Count_Teams;
            return Convert.ToInt32(dbMan.ExecuteScalar(StoredProcedureName, null));
        }
        public int Count_Submissions()
        {
            string StoredProcedureName = StoredProcedures.Count_Submissions;
            return Convert.ToInt32(dbMan.ExecuteScalar(StoredProcedureName, null));
        }

        public int Select_Id_by_Email(string email)
        {
            string StoredProcedureName = StoredProcedures.Select_Id_by_Email;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Email", email);
            return Convert.ToInt32(dbMan.ExecuteScalar(StoredProcedureName, Parameters));
        }
    }
}
