using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        [Key]
        public uint id { get; set; }
        public uint usertypeid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string registrationnumber { get; set; }
        public string phone { get; set; }
    
        public User(uint id, uint usertypeid, string name, string email, string password, string registrationnumber, string phone)
        {
            this.id = id;
            this.usertypeid = usertypeid;
            this.name = name;
            this.email = email;
            this.password = password;
            this.registrationnumber = registrationnumber;
            this.phone = phone;
        }
        public User(uint usertypeid, string name, string email, string password, string registrationnumber, string phone)
        {;
            this.usertypeid = usertypeid;
            this.name = name;
            this.email = email;
            this.password = password;
            this.registrationnumber = registrationnumber;
            this.phone = phone;
        }
    }
}
