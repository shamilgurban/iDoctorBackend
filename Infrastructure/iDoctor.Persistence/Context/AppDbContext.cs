using iDoctor.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace iDoctor.Persistence.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
