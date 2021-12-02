using Microsoft.EntityFrameworkCore;

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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSubject>().HasKey(u => new { u.StudentID, u.SubjectID } );
            modelBuilder.Entity<UniversityTeacher>().HasKey(u => new { u.TeacherID, u.UniversityID });
        }
    }
}