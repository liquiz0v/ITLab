using ITLab.Cabinet.Database.Models;
using ITLab.Cabinet.Logic.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITLab.Cabinet.Logic.Queries.Interfaces
{
    public interface ICoursesQueries
    {
        public List<CourseDTO> GetCourseWithSchedule();
        public List<CourseScheduleDTO> GetSchedule(int courseId);
        public List<Course> GetStudentCourses(int studentId);
    }
}
