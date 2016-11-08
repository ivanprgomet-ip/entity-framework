using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._1_2_
{
    class EducationContext:DbContext
    {
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses{ get; set; }
        public DbSet<Student> Students{ get; set; }
    }
}
