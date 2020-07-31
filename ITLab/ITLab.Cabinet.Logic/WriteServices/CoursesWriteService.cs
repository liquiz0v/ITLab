using ITLab.Cabinet.Logic.Queries;
using ITLab.Cabinet.Logic.Queries.Interfaces;
using ITLab.Cabinet.Logic.Repository;
using ITLab.Cabinet.Logic.Repository.Interfaces;
using ITLab.Cabinet.Logic.WriteServices.Interfaces;

namespace ITLab.Cabinet.Logic.WriteServices
{
    public class CoursesWriteService : ICoursesWriteService
    {
        private readonly ICoursesRepository _repository;
        private readonly ICoursesQueries _queries;

        public CoursesWriteService(ICoursesRepository repository, ICoursesQueries queries)
        {
            _repository = repository;
            _queries = queries;
        }
    }
}