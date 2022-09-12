using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.Models
{
    public class Graduate
    {
        [PrimaryKey]
        public string ID { get; set; }
        public string StudentID { get; set; }
        public string WorkplaceName { get; set; }
        public uint UnivercityID { get; set; }
        public uint CareerID { get; set; }
        public uint GraduateYear { get; set; }

    }
}
