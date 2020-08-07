using ITLab.Cabinet.Logic.Queries;
using ITLab.Cabinet.Logic.Queries.Interfaces;
using ITLab.Cabinet.Logic.Repository;
using ITLab.Cabinet.Logic.Repository.Interfaces;
using ITLab.Cabinet.Logic.WriteServices.Interfaces;

namespace ITLab.Cabinet.Logic.WriteServices
{
    public class StudentWriteService : IStudentWriteService
    {
        private readonly IStudentRepository _repository;
        private readonly IStudentQueries _queries;

        public StudentWriteService(IStudentRepository repository, IStudentQueries queries)
        {
            _repository = repository;
            _queries = queries;
        }
    }
}