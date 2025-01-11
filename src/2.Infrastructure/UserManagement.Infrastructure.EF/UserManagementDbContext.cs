using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Infrastructure.EF
{
    public class UserManagementDbContext : DbContext
    {
        public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}