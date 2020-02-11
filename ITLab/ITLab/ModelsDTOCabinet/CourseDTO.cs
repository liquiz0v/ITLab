using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLab.Models_cabinet;

namespace ITLab.ModelsDTOCabinet
{
    public class CourseDTO : Course
    {
        private readonly CabinetContext _context;

        public Course GetOne(int Id)
        {
           var course = _context.Courses.Find(Id);
            return course;
        }
        
    }
}
