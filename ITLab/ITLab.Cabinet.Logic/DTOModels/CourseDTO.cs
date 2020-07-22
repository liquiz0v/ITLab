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
            Schedule = new List<CourseScheduleDTO>();
        }

        public List<CourseScheduleDTO> Schedule { get; set; }
    }
}
