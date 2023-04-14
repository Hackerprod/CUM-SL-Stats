using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace SKYNET.Models
{
    [Table("Plan")]
    public class Plan : DBModel
    {
        //[ForeignKey(typeof(Subject))]
        public uint SubjectID { get; set; }
        public SchoolYear Year { get; set; }
        public Semester Semester { get; set; }
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
