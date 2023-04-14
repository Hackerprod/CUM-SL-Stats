using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.Models
{
    public class DBModel
    {
        [PrimaryKey, AutoIncrement]
        [Indexed]
        public uint ID { get; set; }
    }
}
