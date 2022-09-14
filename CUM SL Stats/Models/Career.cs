using System;
using SQLite;

namespace SKYNET.Models
{
    [Serializable]
    public class Career 
    {
        [PrimaryKey]
        public uint ID { get; set; }
        public string Name { get; set; }
        public uint StudyPlanID { get; set; }
    }
}
