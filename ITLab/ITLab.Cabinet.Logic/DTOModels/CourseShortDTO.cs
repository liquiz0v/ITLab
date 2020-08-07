using ITLab.Cabinet.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITLab.Cabinet.Logic.DTOModels
{
    public class CourseShortDTO
    {
        public CourseShortDTO()
        {
            LessonTimes = new List<CourseScheduleDTO>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Photo HeadPhoto { get; set; }
        public List<CourseScheduleDTO> LessonTimes { get; set; }
    }
}
