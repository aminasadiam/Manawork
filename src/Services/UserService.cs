using System;
using System.Linq;
using Manawork.Models.User;
using Manawork.Services.Interfaces;
using Manawork.Contxet;
using Manawork.DTOs.Users;

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

        public int GetUserIdByEmail(string email)
        {
            return _context.Users.First(u => u.Email == email).UserId;
        }

        public bool IsEmailExist(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsUsernameExist(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public User LoginUser(LoginViewModel model)
        {
            string email = model.Email.ToLower();
            string pass = model.Password;

            return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == pass);
        }
    }
}