﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iDoctor.Persistence.Context;

#nullable disable

namespace iDoctor.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("iDoctor.Domain.Entities.BloodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BloodTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "O(I) Rh+"
                        },
                        new
                        {
                            Id = 2,
                            Type = "O(I) Rh-"
                        },
                        new
                        {
                            Id = 3,
                            Type = "A(II) Rh+"
                        },
                        new
                        {
                            Id = 4,
                            Type = "A(II) Rh-"
                        },
                        new
                        {
                            Id = 5,
                            Type = "B(III) Rh+"
                        },
                        new
                        {
                            Id = 6,
                            Type = "B(III) Rh-"
                        },
                        new
                        {
                            Id = 7,
                            Type = "AB(IV) Rh+"
                        },
                        new
                        {
                            Id = 8,
                            Type = "AB(IV) Rh-"
                        });
                });

            modelBuilder.Entity("iDoctor.Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClinicAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClinicName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<int?>("SpecialtyId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("VerificationDocumentPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecialtyId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("iDoctor.Domain.Entities.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("FieldOfStudy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("iDoctor.Domain.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Qadın"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Kişi"
                        });
                });

            modelBuilder.Entity("iDoctor.Domain.Entities.MaritalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MaritalStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "Subay"
                        },
                        new
                        {
                            Id = 2,
                            Status = "Evli"
                        });
                });

            modelBuilder.Entity("iDoctor.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BloodTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("HealthRecord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaritalStatusId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BloodTypeId");

                    b.HasIndex("GenderId");

                    b.HasIndex("MaritalStatusId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("iDoctor.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "VerifyDoctor",
                            UserType = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "CreateAppointment",
                            UserType = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "CreateAppointment",
                            UserType = 3
                        },
                        new
                        {
                            Id = 4,
                            Name = "UpdatePatient",
                            UserType = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "UpdateDoctor",
                            UserType = 3
                        });
                });

            modelBuilder.Entity("iDoctor.Domain.Entities.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specialties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kardiologiya"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Nevrologiya"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Dermatologiya"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Pediatriya"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Onkologiya"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Ginekologiya"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Travmatologiya"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Ortopediya"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Oftalmologiya"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Endokrinologiya"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Cərrahiyyə"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Urologiya"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Nefrologiya"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Psixiatriya"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Pulmonologiya"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Hematologiya"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Reabilitasiya"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Rheumatologiya"
                        });
                });

            modelBuilder.Entity("iDoctor.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("iDoctor.Domain.Entities.Doctor", b =>
                {
                    b.HasOne("iDoctor.Domain.Entities.Specialty", "Specialty")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecialtyId");

                    b.HasOne("iDoctor.Domain.Entities.User", "User")
                        .WithOne("Doctor")
                        .HasForeignKey("iDoctor.Domain.Entities.Doctor", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialty");

                    b.Navigation("User");
                });

            modelBuilder.Entity("iDoctor.Domain.Entities.Education", b =>
                {
                    b.HasOne("iDoctor.Domain.Entities.Doctor", "Doctor")
                        .WithMany("Educations")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("iDoctor.Domain.Entities.Patient", b =>
                {
                    b.HasOne("iDoctor.Domain.Entities.BloodType", "BloodType")
                        .WithMany("Patients")
                        .HasForeignKey("BloodTypeId");

                    b.HasOne("iDoctor.Domain.Entities.Gender", "Gender")
                        .WithMany("Patients")
                        .HasForeignKey("GenderId");

                    b.HasOne("iDoctor.Domain.Entities.MaritalStatus", "MaritalStatus")
                        .WithMany("Patients")
                        .HasForeignKey("MaritalStatusId");

                    b.HasOne("iDoctor.Domain.Entities.User", "User")
                        .WithOne("Patient")
                        .HasForeignKey("iDoctor.Domain.Entities.Patient", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BloodType");

                    b.Navigation("Gender");

                    b.Navigation("MaritalStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("iDoctor.Domain.Entities.BloodType", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("iDoctor.Domain.Entities.Doctor", b =>
                {
                    b.Navigation("Educations");
                });

            modelBuilder.Entity("iDoctor.Domain.Entities.Gender", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("iDoctor.Domain.Entities.MaritalStatus", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("iDoctor.Domain.Entities.Specialty", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("iDoctor.Domain.Entities.User", b =>
                {
                    b.Navigation("Doctor")
                        .IsRequired();

                    b.Navigation("Patient")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
