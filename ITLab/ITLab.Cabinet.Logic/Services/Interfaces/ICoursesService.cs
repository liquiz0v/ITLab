using ITLab.Cabinet.Logic.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITLab.Cabinet.Logic.Services.Interfaces
{
    public interface ICoursesService
    {
        public CourseDTO GetShortCourse(int courseId);
    }
}
