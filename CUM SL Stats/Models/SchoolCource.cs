using SQLite.Net.Attributes;
using System;

namespace SKYNET.Models
{
    [Serializable]
    public class SchoolCource : DBModel
    {
        [Indexed]
        public string Name { get; set; }
    }
}
