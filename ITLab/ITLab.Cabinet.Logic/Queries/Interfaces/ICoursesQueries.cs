using ITLab.Cabinet.Database.Models;
using ITLab.Cabinet.Logic.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITLab.Cabinet.Logic.Queries.Interfaces
{
    public interface ICoursesQueries
    {
        public CourseDTO GetShortCourse(int courseId);
        public List<CourceShortLessonTimeDTO> GetCourseLessons(int courseId);
    }
}
