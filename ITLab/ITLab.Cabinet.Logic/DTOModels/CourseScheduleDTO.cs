using System;
using System.Collections.Generic;
using System.Text;

namespace ITLab.Cabinet.Logic.DTOModels
{
    public class CourseScheduleDTO
    {
        public int DayOfWeek { get; set; }
        public DateTime LessonDateFrom { get; set; }
        public DateTime LessonDateTo { get; set; }
    }
}
