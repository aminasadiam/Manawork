using Manawork.Models.User;
using Manawork.DTOs.Users;

namespace Manawork.Services.Interfaces
{
    public interface IUserService
    {
        bool IsUsernameExist(string username);
        bool IsEmailExist(string email);
        void AddUser(User user);
        User LoginUser(LoginViewModel model);
    }
}