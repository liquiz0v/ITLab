using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ITLab.Models;
using Microsoft.EntityFrameworkCore;
using ITLab.ModelsDTOCabinet;
using ITLab.Models_cabinet;

namespace ITLab.ModelsDTOCabinet
{
    public class StudentDTO : Student
    {
        private readonly CabinetContext _context;
    
        public StudentDTO(CabinetContext context)
        {
            _context = context;
        }
       
        public Student GetOne(int Id)
        {
            Student student = _context.Students.Find(Id);
            return student;
        }
        public object GetStudentCourses(int Id)
        {
            var cources = _context.StudentsCourses.Where(n => n.Student.StudentId == Id)
                .Join(_context.Courses, c => c.Course.CourseId, sc => sc.CourseId, (c, sc) => new { c, sc })
                .Select(f => new
                {
                    f.c.Course.CourseId,
                    f.c.Course.Description,
                    f.c.Course.Name
                }).ToList();
            return cources;
        }

    }
}
