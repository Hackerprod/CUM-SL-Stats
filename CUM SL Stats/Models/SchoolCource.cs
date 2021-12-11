using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SKYNET.Models
{
    [Serializable]
    public class SchoolCource
    {
        [PrimaryKey]
        public uint ID { get; set; }
        public string Name { get; set; }
    }
}
