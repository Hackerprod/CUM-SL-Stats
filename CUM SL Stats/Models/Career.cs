using System;

namespace SKYNET.Models
{
    [Serializable]
    public class Career 
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public uint StudyPlanID { get; set; }
    }
}
