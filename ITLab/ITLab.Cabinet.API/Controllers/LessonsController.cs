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
    [Route("api/")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonsReadService _lessonsReadService;
        public LessonsController(LessonsReadService lessonsReadService)
        {
            _lessonsReadService = lessonsReadService;
        }

        [HttpGet("Lessons/")]
        public async Task<object> GetLessonsByCourseId(int courseId, int studentId) 
        {
            return await _lessonsReadService.GetLessonsAsync(courseId, studentId).ConfigureAwait(false);
        }

        [HttpGet("Lesson/")]
        public async Task<object> GetLessonByLessonId(int lessonId, int studentId)
        {
            return await _lessonsReadService.GetLessonByLessonId(lessonId, studentId).ConfigureAwait(false);
        }
    }
}
