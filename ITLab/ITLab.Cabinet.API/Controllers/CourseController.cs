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
    public class CourseController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ICoursesService _coursesService;
        public CourseController(StudentService studentService, CoursesService coursesService)
        {
            _studentService = studentService;
            _coursesService = coursesService;
        }

        [HttpPost]
        public object GetCourseSchedule()
        {
            var response = _coursesService.GetCourseSchedule();
            return response;
        }

        [HttpGet]
        public object GetStudentCourses(int studentId)
        {
            var response = _coursesService.GetStudentCourses(studentId);
            return response;
        }
    }
}
