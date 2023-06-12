using SQLite.Net.Attributes;
using System;

namespace SKYNET.Models
{
    [Serializable]
    public class Career : DBModel
    {
        [Indexed]
        public string Name { get; set; }
    }
}
