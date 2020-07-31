using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ITLab.Cabinet.Database.Models
{
    public class CabinetContext : DbContext
    {
        public CabinetContext()
        {
            
        }
        public CabinetContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Presentations> Presentations { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentsCourses> StudentsCourses { get; set; }
    }
}