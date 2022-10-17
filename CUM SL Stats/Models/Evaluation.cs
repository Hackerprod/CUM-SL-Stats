using System;

namespace SKYNET.Models
{
    [Serializable]
    public class Evaluation
    {
        public uint ID { get; set; }
        public uint CourceID { get; set; }
        public uint CareerID { get; set; }
        public uint GroupID { get; set; }
        public uint SubjectID { get; set; }
        public ulong StudentID { get; set; }
        public string Points { get; set; }
        public Semester Semester { get; set; }
    }
}
