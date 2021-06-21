using Manawork.Models.User;

namespace Manawork.Services.Interfaces
{
    public interface IUserService
    {
        bool IsUsernameExist(string username);
        bool IsEmailExist(string email);
        void AddUser(User user);
    }
}