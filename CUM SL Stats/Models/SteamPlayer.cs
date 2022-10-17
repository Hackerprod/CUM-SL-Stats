using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.Models
{
    public class SteamPlayer
    {
        public uint AccountID { get; set; }
        public string AccountName { get; set; }
        public object Password { get; internal set; }
    }
}
