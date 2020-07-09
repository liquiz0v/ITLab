using ITLab.Cabinet.Logic.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITLab.Cabinet.Logic.Services.Interfaces
{
    public interface IStudentService
    {
        public StudentDTO GetStudent(int studentId);

        public List<CourseDTO> GetStudentCources(int studentId);

        public List<LessonDTO> GetStudentLessons(int studentId);



    }
}
