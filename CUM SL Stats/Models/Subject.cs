using System;
using SQLite;

namespace SKYNET.Models
{
    [Serializable]
    public class Subject
    {
        [PrimaryKey]
        public uint ID { get; set; }
        public string Name { get; set; }
    }
}
