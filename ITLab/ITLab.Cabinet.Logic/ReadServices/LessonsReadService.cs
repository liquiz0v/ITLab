using ITLab.Cabinet.Logic.DTOModels;
using ITLab.Cabinet.Logic.Queries;
using ITLab.Cabinet.Logic.Queries.Interfaces;
using ITLab.Cabinet.Logic.ReadServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITLab.Cabinet.Logic.ReadServices
{
    public class LessonsReadService : ILessonsReadService
    {
        private readonly ILessonsQueries _lessonsQueries;
        public LessonsReadService(ILessonsQueries lessonsQueries)
        {
            _lessonsQueries = lessonsQueries;
        }

        public async Task<IEnumerable<DetailedLessonDTO>> GetLessonByLessonId(int lessonId, int studentId)
        {
            return await _lessonsQueries.GetLessonByLessonId(lessonId, studentId);
        }

        public async Task<IEnumerable<LessonDTO>> GetLessonsAsync(int courseId, int studentId)
        {
            return await _lessonsQueries.GetLessonsAsync(courseId, studentId);
        }
    }
}
