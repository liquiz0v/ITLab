using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITLab.Models_cabinet
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}