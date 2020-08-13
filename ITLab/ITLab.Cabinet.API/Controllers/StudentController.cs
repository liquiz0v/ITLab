using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLab.Cabinet.Logic.ReadServices;
using ITLab.Cabinet.Logic.ReadServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITLab.Cabinet.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentReadService _studentService;
        private readonly ICoursesReadService _coursesService;
        public StudentController(StudentReadService studentService, CoursesReadService coursesService)
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
            var response = _studentService.GetStudentCourses(studentId);
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
