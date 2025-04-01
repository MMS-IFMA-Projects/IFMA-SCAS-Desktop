using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository()
        {
            //_context = new AppDbContext();
            AppDbContext context = new AppDbContext();
            context.Database.EnsureCreated();
            _context = context;
        }

        public async Task<User> createUser(uint usertype, string name, string email, string password, string registrationnumber, string phone)
        {
            User userObj = new User(usertype, name, email, password, registrationnumber, phone);
            userObj.id = 4;

            await this._context.Users.AddAsync(userObj);

            return userObj;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.id == id);
        }
    }
}
