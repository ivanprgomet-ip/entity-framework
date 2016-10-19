using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class SchoolContext:DbContext
    {
        DbSet<Education> Educations { get; set; }
        DbSet<School> Schools{ get; set; }
        DbSet<School> Students{ get; set; }
    }
}
