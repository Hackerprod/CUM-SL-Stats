using System;
using SQLite;

namespace SKYNET.Models
{
    [Serializable]
    public class Group 
    {
        [PrimaryKey]
        public uint ID { get; set; }
        public string Name { get; set; }
        public uint CourceID { get; set; }
        public uint CareerID { get; set; }
    }
}
