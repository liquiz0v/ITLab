using ITLab.Cabinet.Database.Models;
using ITLab.Cabinet.Logic.DTOModels;
using ITLab.Cabinet.Logic.Queries.Interfaces;
using ITLab.Cabinet.Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITLab.Cabinet.Logic.Services
{
    public class CoursesService : ICoursesService
    {
        readonly ICoursesQueries _queries;

        public CoursesService(ICoursesQueries queries)
        {
            _queries = queries;
        }

        public List<Course> GetStudentCourses(int studentId)
        {
            return _queries.GetStudentCourses(studentId);
        }

        public List<CourseDTO> GetCourseSchedule()
        {
            return _queries.GetCourseWithSchedule();
        }

        public List<LessonDTO> GetCourseLessons(int courseId)
        {
            var lessons = _queries.GetCourseLessons(courseId);
            return lessons;
        }
    }
}
