
using UserManagement.Domain.Core.Enums;

namespace UserManagement.Domain.Core.Entities
{
    public class User
    {
        #region properties
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime RegisteredAt { get; set; }
        public UserMembershipTypeEnum MembershipType { get; set; }
        #endregion
    }
}
