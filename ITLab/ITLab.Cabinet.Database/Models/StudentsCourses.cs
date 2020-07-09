

namespace ITLab.Cabinet.Database.Models
{
    public class StudentsCourses
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}