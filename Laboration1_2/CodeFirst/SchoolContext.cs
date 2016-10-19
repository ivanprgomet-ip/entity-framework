using System.Collections.Generic;
using System.Data.Entity;

namespace CodeFirst
{
    internal class SchoolContext:DbContext
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }

        public DbSet<Education> Educations { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}