using SQLite.Net.Attributes;
using System;

namespace SKYNET.Models
{
    [Serializable]
    public class Evaluation : DBModel
    {
        [Indexed]
        public uint CourceID { get; set; }
        [Indexed]
        public uint CareerID { get; set; }
        [Indexed]
        public uint GroupID { get; set; }
        [Indexed]
        public uint SubjectID { get; set; }
        [Indexed]
        public string StudentID { get; set; }
        [Indexed]
        public string Points { get; set; }
        public Semester Semester { get; set; }
    }
}
