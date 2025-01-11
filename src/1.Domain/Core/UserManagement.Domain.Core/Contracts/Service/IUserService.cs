

using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Core.Contracts.Service
{
    public interface IUserService 
    {
        List<User> GetAll();
        User? GetById(int id);
        bool Create(User user);
        bool Update(User user);
        bool Delete(int id);
    }
}
