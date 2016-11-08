using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._1_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            //allways drop and recreate database, then add default data to database
            Database.SetInitializer(new DropCreateDatabaseAlways<EducationContext>());
            GenerateStudents();

            //print all the students and their enrollments, and the corresponding courses
            using (EducationContext context = new EducationContext())
            {
                foreach (var stud in context.Students)
                {
                    Console.WriteLine(stud.FirstMidName);
                    foreach (var course in stud.Enrollment.Courses)
                    {
                        Console.WriteLine(course.CourseName);
                    }
                    Console.WriteLine("......................");
                }
            }
        }
        public static void GenerateStudents()
        {
            Course EntityFrameworkCourse = new Course() { CourseName = "Entity Framework", Credits = 50 };
            Course DotNetFrameworkCourse = new Course() { CourseName = ".NET Framework", Credits = 50 };
            Course JavascriptCourse = new Course() { CourseName = "Javascript", Credits = 50 };
            Course BasicAlgorithms = new Course() { CourseName = "Basic Algorithms", Credits = 50 };

            Course HttpCourse = new Course() { CourseName = "Http", Credits = 100 };
            Course SecurityManagementCourse = new Course() { CourseName = "Security Management", Credits = 50 };

            Enrollment e1 = new Enrollment()
            {
                Courses = new HashSet<Course> { EntityFrameworkCourse, DotNetFrameworkCourse, JavascriptCourse, BasicAlgorithms },
                EnrollmentName = "Webbdeveloper within .NET",
                Grade = "A-F",
            };
            Enrollment e2 = new Enrollment()
            {
                Courses = new HashSet<Course> { HttpCourse, SecurityManagementCourse },
                EnrollmentName = "Network Security",
                Grade = "A-F",
            };

            Student student1 = new Student()
            {
                FirstMidName = "Ivan",
                LastName = "Prgomet",
                EnrollmentDate = new DateTime(2015, 12, 24),
                Enrollment = e1
            };
            Student student2 = new Student()
            {
                FirstMidName = "Lea",
                LastName = "Winchester",
                EnrollmentDate = new DateTime(2015, 12, 24),
                Enrollment = e1
            };
            Student student3 = new Student()
            {
                FirstMidName = "Jason",
                LastName = "Bourne",
                EnrollmentDate = new DateTime(2015, 08, 11),
                Enrollment = e2
            };

            using (EducationContext context = new EducationContext())
            {
                
                context.Students.Add(student1);
                context.Students.Add(student2);
                context.Students.Add(student3);
                //context.Database.Log = Console.WriteLine;
                context.SaveChanges();
            }
        }
    }
}
