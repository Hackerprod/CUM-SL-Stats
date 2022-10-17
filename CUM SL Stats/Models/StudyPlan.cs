using System.Collections.Generic;

namespace SKYNET.Models
{
    public class StudyPlan
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public List<Plan> Plans { get; set; }

        public StudyPlan()
        {
            Plans = new List<Plan>();
        }
    }
}
