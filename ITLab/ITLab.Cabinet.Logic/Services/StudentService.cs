using System;
using System.Collections.Generic;
using System.Text;
using ITLab.Cabinet.Logic.Queries;
using ITLab.Cabinet.Logic.Services.Interfaces;
using ITLab.Cabinet.Logic.DTOModels;
using ITLab.Cabinet.Logic.Queries.Interfaces;

namespace ITLab.Cabinet.Logic.Services
{
    public class StudentService : IStudentService
    {
        IStudentQueries _queries;

        public StudentService(IStudentQueries queries)
        {
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
