using System;

namespace SKYNET.Models
{
    [Serializable]
    public class Student : DBModel
    {
        public string CI { get; set; }
        public string Names { get; set; }
        public uint GroupID { get; set; }
        public Status Status { get; set; }
        public Sex Sex { get; set; }
    }

    public enum Sex
    {
        Unknown,
        F,
        M
    }

    public enum Status
    {
        Unknown,
        Active,
        Graduated,
        Down
    }
}
