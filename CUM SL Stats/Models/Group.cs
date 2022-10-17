using System;

namespace SKYNET.Models
{
    [Serializable]
    public class Group 
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public uint CourceID { get; set; }
        public uint CareerID { get; set; }
        public uint StudyPlanID { get; set; }
    }
}
