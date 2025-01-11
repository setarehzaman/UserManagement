

using UserManagement.Domain.Core.Contracts.Repository;
using UserManagement.Domain.Core.Contracts.Service;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool Create(User user)
        {
            if (_userRepository.CheckNationalCode(user.NationalCode))
            {
                user.RegisteredAt = DateTime.Now;
                return _userRepository.Create(user);
            }
            return false;
        }
        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }
        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }
        public User? GetById(int id)
        {
            return _userRepository.GetById(id);
        }
        public bool Update(User user)
        {
            return _userRepository.Update(user);
        }
    }
}
