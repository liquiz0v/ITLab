using System;
using System.Collections.Generic;
using System.Text;
using ITLab.Cabinet.Database.Models;

namespace ITLab.Cabinet.Logic.DTOModels
{
    public class LessonDTO : Lesson
    {
        public int CourseId { get; set; }
        public int CompletedTasksCount { get; set; }
        public int TasksCount { get; set; }
    }
}
