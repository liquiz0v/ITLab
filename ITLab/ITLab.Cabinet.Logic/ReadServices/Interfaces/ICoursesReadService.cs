using System.Collections.Generic;
using ITLab.Cabinet.Database.Models;
using ITLab.Cabinet.Logic.DTOModels;

namespace ITLab.Cabinet.Logic.ReadServices.Interfaces
{
    public interface ICoursesReadService
    {
        public List<CourseDTO> GetCourseSchedule();
        public List<Course> GetStudentCourses(int studentId);
        public List<LessonDTO> GetCourseLessons(int courseId);

    }
}
