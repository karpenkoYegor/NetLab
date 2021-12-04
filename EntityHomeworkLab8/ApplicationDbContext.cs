using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace UniversityDb
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<University> University { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentSubject> StudentSubject { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<UniversityTeacher> UniversityTeacher { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=UniversityDb;Trusted_Connection=True;");
            optionsBuilder.LogTo(message => Debug.WriteLine(message), new[] {RelationalEventId.CommandExecuted});
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<University>().HasKey(u => u.UniversityID);
            modelBuilder.Entity<City>().HasKey(u => u.CityID);
            modelBuilder.Entity<Group>().HasKey(u => u.GroupID);
            modelBuilder.Entity<Student>().HasKey(u => u.StudentID);
            modelBuilder.Entity<Subject>().HasKey(u => u.SubjectID);
            modelBuilder.Entity<Teacher>().HasKey(u => u.TeacherID);
            modelBuilder.Entity<University>()
                .HasOne(u => u.City)
                .WithMany(c => c.University)
                .HasForeignKey(u => u.CityID);
            modelBuilder.Entity<Group>()
                .HasOne(u => u.University)
                .WithMany(c => c.Group)
                .HasForeignKey(u => u.UniversityID);
            modelBuilder.Entity<Student>()
                .HasOne(u => u.City)
                .WithMany(c => c.Student)
                .HasForeignKey(u => u.CityID);
            modelBuilder.Entity<Student>()
                .HasOne(u => u.Group)
                .WithMany(c => c.Student)
                .HasForeignKey(u => u.GroupID);
            modelBuilder.Entity<Teacher>()
                .HasOne(u => u.Subject)
                .WithMany(c => c.Teacher)
                .HasForeignKey(u => u.SubjectID);
            modelBuilder.Entity<UniversityTeacher>()
                .HasOne(u => u.Teacher)
                .WithMany(c => c.UniversityTeacher)
                .HasForeignKey(u => u.TeacherID);
            modelBuilder.Entity<UniversityTeacher>()
                .HasOne(u => u.University)
                .WithMany(c => c.UniversityTeacher)
                .HasForeignKey(u => u.UniversityID);
            modelBuilder.Entity<StudentSubject>()
                .HasOne(u => u.Student)
                .WithMany(c => c.StudentSubject)
                .HasForeignKey(u => u.StudentID);
            modelBuilder.Entity<StudentSubject>()
                .HasOne(u => u.Subject)
                .WithMany(c => c.StudentSubject)
                .HasForeignKey(u => u.SubjectID);
            modelBuilder.Entity<StudentSubject>().HasKey(u => new { u.StudentID, u.SubjectID });
            modelBuilder.Entity<UniversityTeacher>().HasKey(u => new { u.TeacherID, u.UniversityID });
        }
    }
}