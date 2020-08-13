using System.Collections.Generic;
using ITLab.Cabinet.Database.Models;
using ITLab.Cabinet.Logic.DTOModels;
using ITLab.Cabinet.Logic.Queries.Interfaces;
using ITLab.Cabinet.Logic.ReadServices.Interfaces;

namespace ITLab.Cabinet.Logic.ReadServices
{
    public class CoursesReadService : ICoursesReadService
    {
        readonly ICoursesQueries _queries;

        public CoursesReadService(ICoursesQueries queries)
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

        public StudentStatisticsDTO GetStudentStatistics(int studentId, int courseId)
        {
            return _queries.GetStudentStatistics(studentId, courseId);
        }
    }
}
