using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLab_api.Models
{
    public class StudentsContext : DbContext
    {
        public StudentsContext()
        {
        }

        //public StudentsContext() { }

        public StudentsContext(DbContextOptions<StudentsContext> options) 
            : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }

    }
}
