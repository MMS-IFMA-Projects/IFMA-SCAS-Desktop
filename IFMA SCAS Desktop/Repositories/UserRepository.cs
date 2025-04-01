using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository()
        {
            //_context = new AppDbContext();
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
                _context = context;
            }
        }

        public async Task<User> createUser(uint usertype, string name, string email, string password, string registrationnumber, string phone)
        {
            User userObj = new User(usertype, name, email, password, registrationnumber, phone);
            
            await this._context.Users.AddAsync(userObj);

            return userObj;
        }
    }
}
