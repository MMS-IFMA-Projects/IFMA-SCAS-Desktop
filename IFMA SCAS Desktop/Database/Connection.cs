using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class Connection : DbContext
    {
        public Connection(DbContextOptions options) : base(options)
        {
        }

        protected Connection()
        {
        }
    
        public DbSet<Entities.User> Users { get; set; }
    }
}
