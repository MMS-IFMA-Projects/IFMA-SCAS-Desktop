using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("user", Schema = "public")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string registrationnumber { get; set; }
        public string phone { get; set; }
    
        public User(int id, string name, string email, string password, string registrationnumber, string phone)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
            this.registrationnumber = registrationnumber;
            this.phone = phone;
        }
        public User(string name, string email, string password, string registrationnumber, string phone)
        {;
            this.name = name;
            this.email = email;
            this.password = password;
            this.registrationnumber = registrationnumber;
            this.phone = phone;
        }
    }
}
