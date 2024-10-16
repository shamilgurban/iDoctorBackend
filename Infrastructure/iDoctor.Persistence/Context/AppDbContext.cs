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
        public DbSet<Analysis> Analyses { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>().HasData(
                                   new Role { Id = 1,  Name = "VerifyDoctor",UserType=1 },//admin
                                   new Role { Id = 2,  Name = "CreateAppointment",UserType=2 },//doctor
                                   new Role { Id = 3,  Name = "CreateAppointment",UserType=3 },//patient
                                   new Role { Id = 4,  Name = "UpdatePatient",UserType=3 },//patient
                                   new Role { Id = 5,  Name = "UpdateDoctor",UserType=2 },//doctor
                                   new Role { Id = 6,  Name = "RegisterAdmin",UserType=1 },//admin
                                   new Role { Id = 7,  Name = "GetAllUsers", UserType=1 },//admin
                                   new Role { Id = 8,  Name = "GetAllDoctors", UserType=1 },//admin
                                   new Role { Id = 9,  Name = "GetVerifiedDoctors", UserType=3 },//patient
                                   new Role { Id = 10, Name = "GetDoctorById", UserType=1 },//admin
                                   new Role { Id = 11, Name = "GetDoctorById", UserType=2 },//doctor
                                   new Role { Id = 12, Name = "GetDoctorById", UserType=3 },//patient
                                   new Role { Id = 13, Name = "DeleteDoctor", UserType=1 },//admin
                                   new Role { Id = 14, Name = "GetVerifiedDoctors", UserType=1 },//admin
                                   new Role { Id = 15, Name = "GetUnVerifiedDoctors", UserType=1 },//admin
                                   new Role { Id = 16, Name = "GetAllPatients", UserType=1 },//admin
                                   new Role { Id = 17, Name = "GetPatientById", UserType=1 },//admin
                                   new Role { Id = 18, Name = "GetPatientById", UserType=2 },//doctor
                                   new Role { Id = 19, Name = "DeletePatient", UserType=1 },//admin
                                   new Role { Id = 20, Name = "GetAllAnalyses", UserType=1 },//admin
                                   new Role { Id = 21, Name = "GetAllAnalyses", UserType=2 },//doctor
                                   new Role { Id = 22, Name = "GetAllAnalyses", UserType=3 },//patient
                                   new Role { Id = 23, Name = "GetAnalysisById", UserType=1 },//admin
                                   new Role { Id = 24, Name = "CreateAnalysis", UserType=1 },//admin
                                   new Role { Id = 25, Name = "UpdateAnalysis", UserType=1 },//admin
                                   new Role { Id = 26, Name = "DeleteAnalysis", UserType=1 },//admin
                                   new Role { Id = 27, Name = "GetAllAppointments", UserType=1 },//admin
                                   new Role { Id = 28, Name = "GetDoctorsAllAppointmentsById", UserType=2 },//doctor
                                   new Role { Id = 29, Name = "GetDoctorsPendingAppointmentsById", UserType=2 },//doctor
                                   new Role { Id = 30, Name = "GetAppointmentById", UserType=1 },//admin
                                   new Role { Id = 31, Name = "GetAppointmentById", UserType=2 },//doctor
                                   new Role { Id = 32, Name = "DeleteAppointment", UserType=1 },//admin
                                   new Role { Id = 33, Name = "AcceptAppointment", UserType=2 },//doctor
                                   new Role { Id = 34, Name = "DeclineAppointment", UserType=2 },//doctor
                                   new Role { Id = 35, Name = "GetAllBloodTypes", UserType=3 },//patient
                                   new Role { Id = 36, Name = "GetAllBloodTypes", UserType=1 },//admin
                                   new Role { Id = 37, Name = "GetBloodTypeById", UserType=1 },//admin
                                   new Role { Id = 38, Name = "CreateBloodType", UserType=1 },//admin
                                   new Role { Id = 39, Name = "UpdateBloodType", UserType=1 },//admin
                                   new Role { Id = 40, Name = "DeleteBloodType", UserType=1 },//admin
                                   new Role { Id = 41, Name = "GetAllEducations", UserType=1 },//admin
                                   new Role { Id = 42, Name = "GetEducationById", UserType=1 },//admin
                                   new Role { Id = 43, Name = "GetEducationsByDoctorId", UserType=2 },//doctor
                                   new Role { Id = 44, Name = "GetAllGenders", UserType=1 },//admin
                                   new Role { Id = 45, Name = "GetAllGenders", UserType=3 },//patient
                                   new Role { Id = 46, Name = "GetGenderById", UserType=1 },//admin
                                   new Role { Id = 47, Name = "CreateGender", UserType=1 },//admin
                                   new Role { Id = 48, Name = "UpdateGender", UserType=1 },//admin
                                   new Role { Id = 49, Name = "DeleteGender", UserType=1 },//admin
                                   new Role { Id = 50, Name = "GetAllMaritalStatuses", UserType=3 },//patient
                                   new Role { Id = 51, Name = "GetAllMaritalStatuses", UserType=1 },//admin
                                   new Role { Id = 52, Name = "GetMaritalStatusById", UserType=1 },//admin
                                   new Role { Id = 53, Name = "CreateMaritalStatus", UserType=1 },//admin
                                   new Role { Id = 54, Name = "UpdateMaritalStatus", UserType=1 },//admin
                                   new Role { Id = 55, Name = "DeleteMaritalStatus", UserType=1 },//admin
                                   new Role { Id = 56, Name = "GetAllRoles", UserType=1 },//admin
                                   new Role { Id = 57, Name = "GetRoleById", UserType=1 },//admin
                                   new Role { Id = 58, Name = "CreateRole", UserType=1 },//admin
                                   new Role { Id = 59, Name = "UpdateRole", UserType=1 },//admin
                                   new Role { Id = 60, Name = "DeleteRole", UserType=1 },//admin
                                   new Role { Id = 61, Name = "GetAllSpecialties", UserType=2 },//doctor
                                   new Role { Id = 62, Name = "GetAllSpecialties", UserType=1 },//admin
                                   new Role { Id = 63, Name = "GetSpecialtyById", UserType=1 },//admin
                                   new Role { Id = 64, Name = "CreateSpecialty", UserType=1 },//admin
                                   new Role { Id = 65, Name = "UpdateSpecialty", UserType=1 },//admin
                                   new Role { Id = 66, Name = "DeleteSpecialty", UserType=1 },//admin
                                   new Role { Id = 67, Name = "GetPatientById", UserType = 3 }//patient
                                   );

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


            modelBuilder.Entity<Analysis>().HasData(
                
                                   new Analysis { Id = 1,  Name = "Qanın Biokimyəvi müayinələri"},
                                   new Analysis { Id = 2,  Name = "Sidiyin Biokimyəvi müayinələri"},
                                   new Analysis { Id = 3,  Name = "Hemostaz müayinələri"},
                                   new Analysis { Id = 4,  Name = "İnfeksiyaların təyini"},
                                   new Analysis { Id = 5,  Name = "İmmunoloji müayinələr"},
                                   new Analysis { Id = 6,  Name = "Bakterioloji müayinələr"},
                                   new Analysis { Id = 7,  Name = "Molekulyar-bioloji müayinələr"},
                                   new Analysis { Id = 8,  Name = "Allerqoloji müayinələr"},
                                   new Analysis { Id = 9,  Name = "Onkomarker müayinələri"},
                                   new Analysis { Id = 10, Name = "Genetik Testlər"},
                                   new Analysis { Id = 11, Name = "Endokrinoloji müayinələr" },
                                   new Analysis { Id = 12, Name = "Toxuma biopsiyası" },
                                   new Analysis { Id = 13, Name = "Kardioloji testlər" },
                                   new Analysis { Id = 14, Name = "Hormon müayinələri" },
                                   new Analysis { Id = 15, Name = "Autoimmun xəstəliklərin təyini" });

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

            modelBuilder.Entity<Appointment>()
                     .HasOne(p => p.Doctor)
                     .WithMany(g => g.Appointments)
                     .HasForeignKey(p => p.DoctorId)
                     .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                     .HasOne(p => p.Patient)
                     .WithMany(g => g.Appointments)
                     .HasForeignKey(p => p.PatientId)
                     .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                    .HasOne(p => p.Analysis)
                    .WithMany(g => g.Appointments)
                    .HasForeignKey(p => p.AnalysisId)
                    .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
