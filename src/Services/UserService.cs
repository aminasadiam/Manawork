using System;
using System.Linq;
using Manawork.Models.User;
using Manawork.Services.Interfaces;
using Manawork.Contxet;

namespace Manawork.Services
{
    public class UserService : IUserService
    {
        ManaworkContext _context;

        public UserService(ManaworkContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool IsEmailExist(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsUsernameExist(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }
    }
}