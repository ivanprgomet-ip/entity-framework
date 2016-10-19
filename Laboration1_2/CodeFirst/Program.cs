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
            //using (var ctx = new SchoolContext())
            //{

            //    Student student = new Student() { StudentName = "Ivan Prgomet", StudentBirthDate = DateTime.Now.AddYears(-24) };

            //    ctx.Students.Add(student);
            //    ctx.SaveChanges();
            //}

            SchoolContext context = new SchoolContext();
            
            Console.WriteLine(ReturnStudentWithStartLetter(context, "I"));

        }
        public static string ReturnStudentWithStartLetter(SchoolContext context, string letter)
        {
            var stud = context.Students.Where(s => s.StudentName.StartsWith("I") && s.StudentBirthDate.Year > 1990).FirstOrDefault();
            if (stud == null)
                return "no matching student found";
            return stud.StudentName+" "+stud.StudentBirthDate.Year;
        }
    }
}
