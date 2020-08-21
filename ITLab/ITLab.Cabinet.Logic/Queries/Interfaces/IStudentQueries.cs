using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ITLab.Cabinet.Logic.DTOModels;

namespace ITLab.Cabinet.Logic.Queries.Interfaces
{
    public interface IStudentQueries
    {
        public List<CourseDTO> GetStudentCourses(int studentId);
        public List<LessonDTO> GetStudentLessons(int studentId);
        public StudentDTO GetStudent(int studentId);
    }
}
