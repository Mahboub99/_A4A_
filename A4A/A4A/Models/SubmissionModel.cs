using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace A4A.Models
{
    public class SubmissionModel
    {
        public int SubmissionID { get; set; }
        public int ContestantID { get; set; }
        public string SubmissionVerdict { get; set; }
        public int SubmissionMemory { get; set; }
        public int SubmissionTime { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string SubmissionLang { get; set; }
        public string ProblemID { get; set; }
    }

    public class ProblemObject
    {
        public int ContestId;
        public char Index;
        public string Name;
        public string Type;
        public double Points;
        public int Rating;
        public string[] Tags;
    }
    public class MembersHandle
    {
        [JsonProperty(PropertyName = "Handle")]
        public string Handle;
    }
    public class AuthorObject
    {
        public int ContestId;
        public List<MembersHandle> Members = new List<MembersHandle>();
        public string ParticipateType;
        public bool Ghost;
        public int Room;
        public int StartTimeSeconds;
    }
    public class SubmissionObject
    {
        public int Id;
        public int ContestId;
        public int creationTimeSeconds;
        public int relativeTimeSeconds;
        public ProblemObject Problem;
        public AuthorObject Author;
        public string ProgrammingLanguage;
        public string Verdict;
        public string TestSet;
        public int PassedTestCount;
        public int TimeConsumedMillis;
        public int MemoryConsumedBytes;
    }

    public class SubmissionJsonObject
    {
        [JsonProperty(PropertyName = "status")]
        public string Status;

        [JsonProperty(PropertyName = "result")]
        public List<SubmissionObject> SubmissionList;
    }
}