using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLab.Cabinet.Database.Models;
using ITLab.Cabinet.Logic.DTOModels;

namespace ITLab.Cabinet.Logic
{
    public class CourseDTO : Course
    {
        public CourseDTO()
        {
            LessonTimes = new List<CourceShortLessonTimeDTO>();
        }

        public List<CourceShortLessonTimeDTO> LessonTimes { get; set; }
    }
}
