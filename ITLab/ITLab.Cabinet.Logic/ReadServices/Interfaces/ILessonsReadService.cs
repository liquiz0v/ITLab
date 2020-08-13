using ITLab.Cabinet.Logic.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITLab.Cabinet.Logic.ReadServices.Interfaces
{
    public interface ILessonsReadService
    {
        Task<IEnumerable<LessonDTO>> GetLessonsAsync(int courseId, int studentId);
    }
}
