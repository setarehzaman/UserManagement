

using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Core.Contracts.AppService
{
    public interface IUserAppService
    {
        List<User> SearchUsersByPrompt(string searchBY);
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
        List<User> GetAllUsers();
        User GetUserById(int id);   
    }
}
