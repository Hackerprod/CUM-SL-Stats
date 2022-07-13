using System;
using SQLite;

namespace SKYNET.Models
{
    [Serializable]
    public class Subject
    {
        [PrimaryKey]
        public uint ID { get; set; }
        public string Name { get; set; }
        public uint CareerID { get; set; }
        public uint CourceID { get; set; }
        public Semester Semester { get; set; }
        public Year Year { get; set; }

    }

    public enum Semester
    {
        Both,
        First,
        Second
    }

    public enum Year : int
    {
        Onknown = 0,
        First   = 1,
        Second  = 2,
        Third   = 3,
        Fourth  = 4,
        Fifth   = 5
    }
}
