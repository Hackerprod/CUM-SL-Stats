using SQLite;

namespace SKYNET.Models
{
    public class Plan
    {
        [PrimaryKey]
        public uint ID { get; set; }
        public SchoolYear Year { get; set; }
        public Semester Semester { get; set; }
        public uint SubjectID { get; set; }
    }

    public enum SchoolYear : int
    {
        Unknown = 0,
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Fifth = 5,
    }
}
