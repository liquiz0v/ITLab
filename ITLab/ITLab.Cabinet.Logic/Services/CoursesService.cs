using ITLab.Cabinet.Logic.DTOModels;
using ITLab.Cabinet.Logic.Queries.Interfaces;
using ITLab.Cabinet.Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITLab.Cabinet.Logic.Services
{
    public class CoursesService : ICoursesService
    {
        ICoursesQueries _queries;

        public CoursesService(ICoursesQueries queries)
        {
            _queries = queries;
        }

        public List<CourseDTO> GetCourseSchedule()
        {
            return _queries.GetCourseWithSchedule();
        }
    }
}
