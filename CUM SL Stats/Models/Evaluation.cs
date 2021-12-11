using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SKYNET.Models
{
    [Serializable]
    public class Evaluation
    {
        [PrimaryKey]
        public uint ID { get; set; }
        public uint CourceID { get; set; }
        public uint CareerID { get; set; }
        public uint GroupID { get; set; }
        public uint SubjectID { get; set; }
        public string StudentID { get; set; }
        public string Points { get; set; }
        public Semester Semester { get; set; }
    }
}
