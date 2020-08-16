using System.Collections.Generic;
using ITLab.Cabinet.Logic.DTOModels;

namespace ITLab.Cabinet.Logic.ReadServices.Interfaces
{
    public interface IStudentReadService
    {
        public StudentDTO GetStudent(int studentId);

        public List<CourseDTO> GetStudentCourses(int studentId);

        public List<LessonDTO> GetStudentLessons(int studentId);



    }
}
