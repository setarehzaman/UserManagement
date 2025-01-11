

using UserManagement.Domain.Core.Contracts.AppService;
using UserManagement.Domain.Core.Contracts.Service;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.AppService
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }

        public List<User> SearchUsersByPrompt(string prompt)
        {
            var listOfUsers = _userService.GetAll();
            return listOfUsers.Where(u => u.FirstName.Contains(prompt)|| u.LastName.Contains(prompt)).ToList();
        }

        public bool AddUser(User user)
        {
            return _userService.Create(user);
        }
        public bool UpdateUser(User user) 
        { 
            return _userService.Update(user);
        }
        public bool DeleteUser(int id) 
        {
            return _userService.Delete(id);
        }      
        public List<User> GetAllUsers()
        {
            return _userService.GetAll();
        }
        public User GetUserById(int id) 
        {
            return _userService.GetById(id);
        }
    }
}
