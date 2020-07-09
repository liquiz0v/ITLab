using System;
using System.Collections.Generic;
using System.Text;
using ITLab.Cabinet.Logic.Queries;
using ITLab.Cabinet.Logic.Services.Interfaces;
using ITLab.Cabinet.Logic.Queries;
using ITLab.Cabinet.Logic.DTOModels;

namespace ITLab.Cabinet.Logic.Services
{
    public class StudentService : IStudentService
    {
        StudentQueries _queries;

        public StudentService()
        {
            StudentQueries queries = new StudentQueries();
            _queries = queries;
        }
        public StudentDTO GetStudent(int studentId)
        {
            return _queries.GetStudent(studentId);
        }

        public List<CourseDTO> GetStudentCources(int studentId)
        {
            var response = _queries.GetStudentCources(studentId);
            return response;
        }

        public List<LessonDTO> GetStudentLessons(int studentId)
        {
            var response = _queries.GetStudentLessons(studentId);
            return response;
        }
    }

}
