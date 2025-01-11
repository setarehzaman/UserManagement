
using System.Globalization;
using UserManagement.Domain.Core.Contracts.Repository;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Infrastructure.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManagementDbContext _context;

        public UserRepository(UserManagementDbContext context)
        {
            _context = context;
        }

        //Crud
        public bool Create(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null) return false;

            _context.Users.Remove(user);
            return _context.SaveChanges() > 0;
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public bool Update(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u=>u.Id==user.Id); 
            if(existingUser == null) return false;  

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.NationalCode = user.NationalCode;
            existingUser.MembershipType = user.MembershipType;
            existingUser.BirthDate = user.BirthDate;    
            existingUser.Id = user.Id;

            return _context.SaveChanges() > 0;
        }

        public bool CheckNationalCode(string nationalcode)
        {
            var isExistedNationalcode = _context.Users.Any(u => u.NationalCode == nationalcode);
            if (isExistedNationalcode) return false;
            return true;
        }
    }
}
