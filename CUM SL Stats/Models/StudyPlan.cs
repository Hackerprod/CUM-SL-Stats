using SQLite;
using System.Collections.Generic;

namespace SKYNET.Models
{
    public class StudyPlan
    {
        [PrimaryKey]
        public uint ID { get; set; }
        public string Name { get; set; }
        public List<uint> Plans { get; set; }

        public StudyPlan()
        {
            Plans = new List<uint>();
        }
    }
}
