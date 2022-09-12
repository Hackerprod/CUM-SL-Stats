using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.Models
{
    public class StudyPlan
    {
        [PrimaryKey]
        public uint ID { get; set; }
        public string Name { get; set; }
        public List<Plan> Plans { get; set; }

        public StudyPlan()
        {
            Plans = new List<Plan>();
        }

        public class Plan
        {
            [PrimaryKey]
            public uint ID { get; set; }
            public Year Year { get; set; }
            public Semester Semester { get; set; }
            public Subject Subject { get; set; }
        }

        public enum Year : int
        {
            Unknown     = 0,
            First       = 1,
            Second      = 2,
            Third       = 3,
            Fourth      = 4,
            Fifth       = 5,
        }
    }
}
