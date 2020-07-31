using ITLab.Cabinet.Database.Models;
using ITLab.Cabinet.Logic.Repository.Interfaces;

namespace ITLab.Cabinet.Logic.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly CabinetContext _context;

        public CoursesRepository()
        {
            _context = new CabinetContext();
        }
    }
}