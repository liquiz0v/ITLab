using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLab_api.Models
{

    public class CabinetConext : DbContext
    {
        public CabinetConext()
        {
        }

        public CabinetConext(DbContextOptions<CabinetConext> options) 
            : base(options)
        {

        }

        public DbSet<Student> Student { get; set; }

    }
}
