using iDoctor.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace iDoctor.Persistence.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasOne(u => u.Patient)
                        .WithOne(p => p.User)
                        .HasForeignKey<Patient>(p => p.UserId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                       .HasOne(u => u.Doctor)
                       .WithOne(p => p.User)
                       .HasForeignKey<Doctor>(p => p.UserId)
                       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
