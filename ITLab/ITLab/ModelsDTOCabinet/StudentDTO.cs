using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLab.Models_cabinet;

namespace ITLab.ModelsDTOCabinet
{
    public class StudentDTO : Student
    {
        private readonly CabinetContext _context;

        public string test { get; set; }

        public Student GetOne(int Id)
        {
            Student student = _context.Students.Find(Id);
            return student;
        }
        
    }
}
