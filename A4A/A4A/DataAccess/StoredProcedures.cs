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
        public static string Select_User = "Select_User_By_ID";
        public static string Insert_User = "Insert_User";
        public static string Count_Users = "Count_Users";
        public static string Check_Email_And_Password = "Check_Email_And_Password";

        public static string LoadProblems = "selectAllOfProblems";

        public static string InsertContest = "insertContest";
        public static string LoadContests = "SelectAllOfContests";
        public static string InsertContestProblem = "InsertContestProblem";
        public static string SelectContestProblems = "SelectContestProblems";
        public static string Count_Contests = "CountContests";
        public static string LoadMyContests = "LoadMyContests";

        public static string LoadGroups = "SelectAllOfGroups"; 
        public static string LoadGroupsOfUser = "SelectAllOfGroupsOfUser";
        public static string InsertGroup = "InsertGroup";
        public static string Count_Groups = "CountGroups";

        public static string InsertSubmission = "InsertSubmission";
        public static string GetSubmissionByID = "GetSubmissionByID";
        public static string GetProblemNameByID = "GetProblemNameByID";
        public static string Count_Submissions = "CountSubmissions";

        public static string InsertOrg = "InsertOrg";
        public static string Select_All_Orgs = "Select_All_Orgs";
        public static string Select_Orgs_of_Group = "Select_Orgs_of_Group";
        public static string InsertOrgGroups = "InsertOrgGroups";
        public static string Count_Orgs = "CountOrgs";

        public static string InsertTeam = "InsertTeam";
        public static string Select_All_Teams = "Select_All_Teams";
        public static string Select_Teams_of_Member = "Select_Teams_of_Member";
        public static string InsertTeamMembers = "InsertTeamMembers";
        public static string Count_Teams = "CountTeams";
        public static string Select_Id_by_Email = "Select_Id_by_Email";

        public static string Select_Team_By_ID = "Select_Team_By_ID";
        public static string Select_Team_members_Names = "Select_Team_members_Names";

        public static string SelectOrgGroups = "SelectOrgGroups";
        public static string SelectGroupMembers = "SelectGroupMembers";
        public static string SelectTypeById = "SelectTypeById";
        public static string SelectGroupContests = "SelectGroupContests";
    }
}
