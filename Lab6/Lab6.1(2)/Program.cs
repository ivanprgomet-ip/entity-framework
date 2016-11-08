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
            //we do not have the luxury of lazy loading in the classes (virtual on navigation properties)
            //so we have to manually eagerly load using include
            Console.ForegroundColor = ConsoleColor.Cyan;
            using (EducationContext context = new EducationContext())
            {
                foreach (var student in context.Students
                    .Include(e => e.Enrollment)
                    .Include(e => e.Enrollment.Courses)
                    .ToList())
                {
                    Console.WriteLine(student.FirstMidName+" "+student.LastName + "\nEnrolled to: " + student.Enrollment.EnrollmentName);
                    foreach (var course in student.Enrollment.Courses)
                    {
                        Console.WriteLine(course.CourseID + "# " + course.CourseName + " (" + course.Credits + "p) ");
                    }
                    Console.WriteLine("......................");
                    Console.WriteLine();
                }
            }
            Console.ResetColor();
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
                //context.Courses.AddRange(new List<Course>() { EntityFrameworkCourse, DotNetFrameworkCourse, JavascriptCourse, BasicAlgorithms, HttpCourse, SecurityManagementCourse });
                //context.Enrollments.AddRange(new List<Enrollment>() { e1, e2 });
                context.Students.AddRange(new List<Student> { student1, student2, student3 });
                context.Database.Log = Console.WriteLine;
                context.SaveChanges();

                //detach, koppla loss entiteten från kontexten
            }
        }
    }
}
