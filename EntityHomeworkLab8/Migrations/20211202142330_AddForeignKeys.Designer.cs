﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityDb;

namespace UniversityDb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211202142330_AddForeignKeys")]
    partial class AddForeignKeys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UniversityDb.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.HasKey("CityID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("UniversityDb.Group", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniversityID")
                        .HasColumnType("int");

                    b.HasKey("GroupID");

                    b.HasIndex("UniversityID");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("UniversityDb.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Bonus")
                        .HasColumnType("int");

                    b.Property<int>("Bursary")
                        .HasColumnType("int");

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.HasIndex("CityID");

                    b.HasIndex("GroupID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("UniversityDb.StudentSubject", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.HasKey("StudentID", "SubjectID");

                    b.HasIndex("SubjectID");

                    b.ToTable("StudentSubject");
                });

            modelBuilder.Entity("UniversityDb.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectID");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("UniversityDb.Teacher", b =>
                {
                    b.Property<int>("TeacherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.HasKey("TeacherID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("UniversityDb.University", b =>
                {
                    b.Property<int>("UniversityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UniversityID");

                    b.HasIndex("CityID");

                    b.ToTable("University");
                });

            modelBuilder.Entity("UniversityDb.UniversityTeacher", b =>
                {
                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.Property<int>("UniversityID")
                        .HasColumnType("int");

                    b.Property<int>("Wage")
                        .HasColumnType("int");

                    b.HasKey("TeacherID", "UniversityID");

                    b.HasIndex("UniversityID");

                    b.ToTable("UniversityTeacher");
                });

            modelBuilder.Entity("UniversityDb.Group", b =>
                {
                    b.HasOne("UniversityDb.University", "University")
                        .WithMany("Group")
                        .HasForeignKey("UniversityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("UniversityDb.Student", b =>
                {
                    b.HasOne("UniversityDb.City", "City")
                        .WithMany("Student")
                        .HasForeignKey("CityID");

                    b.HasOne("UniversityDb.Group", "Group")
                        .WithMany("Student")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("UniversityDb.StudentSubject", b =>
                {
                    b.HasOne("UniversityDb.Student", "Student")
                        .WithMany("StudentSubject")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityDb.Subject", "Subject")
                        .WithMany("StudentSubject")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("UniversityDb.Teacher", b =>
                {
                    b.HasOne("UniversityDb.Subject", "Subject")
                        .WithMany("Teacher")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("UniversityDb.University", b =>
                {
                    b.HasOne("UniversityDb.City", "City")
                        .WithMany("University")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("UniversityDb.UniversityTeacher", b =>
                {
                    b.HasOne("UniversityDb.Teacher", "Teacher")
                        .WithMany("UniversityTeacher")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityDb.University", "University")
                        .WithMany("UniversityTeacher")
                        .HasForeignKey("UniversityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");

                    b.Navigation("University");
                });

            modelBuilder.Entity("UniversityDb.City", b =>
                {
                    b.Navigation("Student");

                    b.Navigation("University");
                });

            modelBuilder.Entity("UniversityDb.Group", b =>
                {
                    b.Navigation("Student");
                });

            modelBuilder.Entity("UniversityDb.Student", b =>
                {
                    b.Navigation("StudentSubject");
                });

            modelBuilder.Entity("UniversityDb.Subject", b =>
                {
                    b.Navigation("StudentSubject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("UniversityDb.Teacher", b =>
                {
                    b.Navigation("UniversityTeacher");
                });

            modelBuilder.Entity("UniversityDb.University", b =>
                {
                    b.Navigation("Group");

                    b.Navigation("UniversityTeacher");
                });
#pragma warning restore 612, 618
        }
    }
}
