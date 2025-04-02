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
            _context = new();
            _context.Database.EnsureCreated();
        }

        public async Task<User> createUser(string name, string email, string password, string registrationnumber, string phone)
        {
            User userObj = new(name, email, password, registrationnumber, phone);
            //userObj.id = 6;

            await this._context.Users.AddAsync(userObj);
            var state = _context.Entry(userObj).State;
            int changes = await this._context.SaveChangesAsync();


            Console.WriteLine($"Rows affected: {changes}");
            Console.WriteLine($"State: {_context.Entry(userObj).State}");

            return userObj;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.id == id) ?? throw new NullReferenceException("Failed to get the user with this ID");
            return user;
        }
    }
}
