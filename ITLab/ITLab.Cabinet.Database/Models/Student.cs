using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITLab.Cabinet.Database.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string AvatarPhoto { get; set; }

        public virtual List<LessonsVisits> LessonsVisits { get; set; }
    }
}