using ITLab_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLab_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsContext _context;
        public StudentsController(StudentsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            return await _context.Students.ToListAsync();
        }

        //api/Students
        [HttpGet("{name}")]
        public async Task<ActionResult<Student>> Get(string name)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Name == name);
            if (student == null)
                return NotFound();
            return student;
        }

    }
}
