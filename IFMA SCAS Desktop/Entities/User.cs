using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public uint id { get; set; }
        public ulong roomid { get; set; }
        public uint usertypeid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string registrationnumber { get; set; }
        public string phone { get; set; }
    }

}
