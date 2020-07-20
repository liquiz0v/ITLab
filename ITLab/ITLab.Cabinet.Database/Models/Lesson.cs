using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITLab.Cabinet.Database.Models
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Course Course { get; set; }
        public DateTime LessonDate { get; set; }
        public DateTime LessonDateFrom { get; set; }
        public DateTime LessonDateTo { get; set; }
        public ICollection<Presentations> Presentations { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}