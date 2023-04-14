using SQLite.Net.Attributes;
using System;

namespace SKYNET.Models
{
    [Serializable]
    public class Group : DBModel
    {
        [Indexed]
        public string Name { get; set; }
        [Indexed]
        public uint CourceID { get; set; }
        [Indexed]
        public uint CareerID { get; set; }
        public uint StudyPlanID { get; set; }
    }
}
