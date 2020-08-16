using System;
using System.Collections.Generic;
using System.Text;

namespace ITLab.Cabinet.Database.Models
{
    public class LessonsVisits
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
        public bool Visited { get; set; }
    }
}
