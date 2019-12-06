using System;
using DataController.Models;
using DataController.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataController.BussinessLogic
{
    public static class ProblemSet
    {
        public static List<Problems> LoadProblems()
        {
            string sql = @"select ProblemName, ProblemTopic, ProblemDifficulty
                           from dbo.Problem;";

            return SqlDataAccess.LoadData<Problems>(sql);
        }
    }
}
