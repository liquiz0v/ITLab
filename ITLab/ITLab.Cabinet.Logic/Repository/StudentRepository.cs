using ITLab.Cabinet.Database.Models;
using ITLab.Cabinet.Logic.Repository.Interfaces;

namespace ITLab.Cabinet.Logic.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CabinetContext _context;

        public StudentRepository()
        {
            _context = new CabinetContext();
        }
    }
}