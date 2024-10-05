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

            modelBuilder.Entity<Role>().HasData(
                                   new Role { Id = 1, Name = "VerifyDoctor",UserType=1 },
                                   new Role { Id = 2, Name = "CreateAppointment",UserType=2 },
                                   new Role { Id = 3, Name = "CreateAppointment",UserType=3 },
                                   new Role { Id = 4, Name = "UpdatePatient",UserType=2 },
                                   new Role { Id = 5, Name = "UpdateDoctor",UserType=3 }
                                                );

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
