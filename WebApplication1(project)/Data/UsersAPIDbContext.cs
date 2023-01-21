using Microsoft.EntityFrameworkCore;
using WebApplication1_project_.Models;

namespace WebApplication1_project_.Data
{
    public class UsersAPIDbContext : DbContext
    {
        public UsersAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }      
    }
}
