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
        public DbSet<Gender> Genders { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Specialty>Specialties { get; set; }
        public DbSet<Education> Educations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>().HasData(
                                   new Role { Id = 1, Name = "VerifyDoctor",UserType=1 },
                                   new Role { Id = 2, Name = "CreateAppointment",UserType=2 },
                                   new Role { Id = 3, Name = "CreateAppointment",UserType=3 },
                                   new Role { Id = 4, Name = "UpdatePatient",UserType=2 },
                                   new Role { Id = 5, Name = "UpdateDoctor",UserType=3 } );

            modelBuilder.Entity<Gender>().HasData(
                                   new Gender { Id = 1, Name = "Qadın" },
                                   new Gender { Id = 2, Name = "Kişi" });

            modelBuilder.Entity<MaritalStatus>().HasData(
                                   new MaritalStatus { Id = 1, Status = "Subay" },
                                   new MaritalStatus { Id = 2, Status = "Evli" });

            modelBuilder.Entity<BloodType>().HasData(
                                   new BloodType { Id = 1, Type = "O(I) Rh+" },
                                   new BloodType { Id = 2, Type = "O(I) Rh-" },
                                   new BloodType { Id = 3, Type = "A(II) Rh+" },
                                   new BloodType { Id = 4, Type = "A(II) Rh-" },
                                   new BloodType { Id = 5, Type = "B(III) Rh+" },
                                   new BloodType { Id = 6, Type = "B(III) Rh-" },
                                   new BloodType { Id = 7, Type = "AB(IV) Rh+" },
                                   new BloodType { Id = 8, Type = "AB(IV) Rh-"});


            modelBuilder.Entity<Specialty>().HasData(
                                   new Specialty { Id = 1,  Name = "Kardiologiya" },       
                                   new Specialty { Id = 2,  Name = "Nevrologiya" },       
                                   new Specialty { Id = 3,  Name = "Dermatologiya" },      
                                   new Specialty { Id = 4,  Name = "Pediatriya" },         
                                   new Specialty { Id = 5,  Name = "Onkologiya" },         
                                   new Specialty { Id = 6,  Name = "Ginekologiya" },      
                                   new Specialty { Id = 7,  Name = "Travmatologiya" },    
                                   new Specialty { Id = 8,  Name = "Ortopediya" },         
                                   new Specialty { Id = 9,  Name = "Oftalmologiya" },      
                                   new Specialty { Id = 10, Name = "Endokrinologiya" },   
                                   new Specialty { Id = 11, Name = "Cərrahiyyə" },       
                                   new Specialty { Id = 12, Name = "Urologiya" },         
                                   new Specialty { Id = 13, Name = "Nefrologiya" },       
                                   new Specialty { Id = 14, Name = "Psixiatriya" },       
                                   new Specialty { Id = 15, Name = "Pulmonologiya" },     
                                   new Specialty { Id = 16, Name = "Hematologiya" },      
                                   new Specialty { Id = 17, Name = "Reabilitasiya" },     
                                   new Specialty { Id = 18, Name = "Rheumatologiya" });   

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

            modelBuilder.Entity<Patient>()
                        .HasOne(p => p.Gender)
                        .WithMany(g => g.Patients)
                        .HasForeignKey(p => p.GenderId);

            modelBuilder.Entity<Patient>()
                        .HasOne(p => p.MaritalStatus)
                        .WithMany(g => g.Patients)
                        .HasForeignKey(p => p.MaritalStatusId);

            modelBuilder.Entity<Patient>()
                        .HasOne(p => p.BloodType)
                        .WithMany(g => g.Patients)
                       .HasForeignKey(p => p.BloodTypeId);

            modelBuilder.Entity<Doctor>()
                      .HasOne(p => p.Specialty)
                      .WithMany(g => g.Doctors)
                     .HasForeignKey(p => p.SpecialtyId);

            modelBuilder.Entity<Education>()
                     .HasOne(p => p.Doctor)
                     .WithMany(g => g.Educations)
                     .HasForeignKey(p => p.DoctorId);    


        }
    }
}
