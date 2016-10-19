using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                
                Student student = new Student() { StudentName = "New st udent", StudentBirthDate = DateTime.Now.AddYears(-45) };

                ctx.Students.Add(student);
                ctx.SaveChanges();
            }
        }
    }
}
