using SQLite.Net.Attributes;

namespace SKYNET.Models
{
    public class Graduate : DBModel
    {
        [Indexed]
        public string StudentID { get; set; }
        public string WorkplaceName { get; set; }
        public uint UnivercityID { get; set; }
        [Indexed]
        public uint CareerID { get; set; }
        [Indexed]
        public uint GraduateYear { get; set; }

    }
}
