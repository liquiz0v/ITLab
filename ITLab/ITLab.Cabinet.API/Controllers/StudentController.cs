using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLab.Cabinet.Logic.Services;
using ITLab.Cabinet.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITLab.Cabinet.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ICoursesService _coursesService;
        public StudentController(StudentService studentService, CoursesService coursesService)
        {
            _studentService = studentService;
            _coursesService = coursesService;
        }

        [HttpGet]
        public object GetStudent(int studentId)
        {
            var response = _studentService.GetStudent(studentId);
            return response;
        }

        [HttpGet]
        public object GetStudentCources(int studentId)
        {
            var response = _studentService.GetStudentCources(studentId);
            return response;
        }
        
        [HttpGet]
        public object GetStudentLessons(int studentId)
        {
            var response = _studentService.GetStudentLessons(studentId);
            return response;
        }
    }
}
