using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITLab.Models_cabinet
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Course Course { get; set; }
        public ICollection<Presentations> Presentations { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}