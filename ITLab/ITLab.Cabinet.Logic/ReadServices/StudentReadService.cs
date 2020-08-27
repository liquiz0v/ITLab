using System.Collections.Generic;
using ITLab.Cabinet.Logic.DTOModels;
using ITLab.Cabinet.Logic.Queries.Interfaces;
using ITLab.Cabinet.Logic.ReadServices.Interfaces;

namespace ITLab.Cabinet.Logic.ReadServices
{
    public class StudentReadService : IStudentReadService
    {
        readonly IStudentQueries _queries;

        public StudentReadService(IStudentQueries queries)
        {
            _queries = queries;
        }
        public StudentDTO GetStudent(int studentId)
        {
            return _queries.GetStudent(studentId);
        }

        public List<CourseDTO> GetStudentCourses(int studentId)
        {
            var response = _queries.GetStudentCourses(studentId);
            return response;
        }

        public List<LessonDTO> GetStudentLessons(int studentId)
        {
            var response = _queries.GetStudentLessons(studentId);
            return response;
        }
    }

}
