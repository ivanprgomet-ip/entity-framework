using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._1
{
    class Program
    {
        public static EducationalContext _context = new EducationalContext();
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<EducationalContext>());
            GenerateStudents();

            using (EducationalContext context = new EducationalContext())
            {

                context.Configuration.LazyLoadingEnabled = false;//disable lazy loading
                Console.WriteLine("We are making an explicit loading");//print line 

                PrintAllStudentsWithInclude(context);//print all students, by iterating over context students and using include for the associated data
                PrintAllStudentsWithEntry(context);//print all students and associated data with the entry load method

                Console.WriteLine("Search for a student (include). Enter firstname >> ");//search for specific student using include method of DbSet<>
                SearchStudentWithInclude(Console.ReadLine(), context);

                Console.WriteLine("Search for a student (entry). Enter firstname >> ");//search for specific student using entry and Load method
                SearchStudentWithEntry(Console.ReadLine(), context);
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

            Student student1 = new Student() { FirstMidName = "Ivan", LastName = "Prgomet", EnrollmentDate = new DateTime(2015, 12, 24) };
            student1.Enrollments = new List<Enrollment>
            {
                new Enrollment() {

                    EnrollmentName ="Webdeveloper within .NET",
                    Course = EntityFrameworkCourse,
                    Grade ="A-F" },
                new Enrollment() {

                    EnrollmentName ="Webdeveloper within .NET",
                    Course = DotNetFrameworkCourse,
                    Grade ="A-F" },
                new Enrollment() {

                    EnrollmentName ="Webdeveloper within .NET",
                    Course = JavascriptCourse,
                    Grade ="A-F" },
                new Enrollment()
                {
                   EnrollmentName ="Webdeveloper within .NET",
                   Course=BasicAlgorithms,
                   Grade="A,F"},
            };
            Student student2 = new Student() { FirstMidName = "Lea", LastName = "Winchester", EnrollmentDate = new DateTime(2015, 12, 24) };
            student2.Enrollments = new List<Enrollment>
            {
                new Enrollment() {

                    EnrollmentName ="Webdeveloper within .NET",
                    Course = EntityFrameworkCourse,
                    Grade ="A-F" },
                new Enrollment() {

                    EnrollmentName ="Webdeveloper within .NET",
                    Course = DotNetFrameworkCourse,
                    Grade ="A-F" },
                new Enrollment() {

                    EnrollmentName ="Webdeveloper within .NET",
                    Course = JavascriptCourse,
                    Grade ="A-F" },
            };
            Student student3 = new Student() { FirstMidName = "Jason", LastName = "Bourne", EnrollmentDate = new DateTime(2016, 12, 24) };
            student3.Enrollments = new List<Enrollment>
            {
                new Enrollment() {

                    EnrollmentName ="Network Security",
                    Course = HttpCourse,
                    Grade ="A,F" },
                new Enrollment() {

                    EnrollmentName ="Network Security",
                    Course = SecurityManagementCourse,
                    Grade ="A-C" },
            };

            using (EducationalContext context = new EducationalContext())
            {
                //context.Configuration.LazyLoadingEnabled = false;

                context.Students.Add(student1);
                context.Students.Add(student2);
                context.Students.Add(student3);
                context.Database.Log = Console.WriteLine;
                context.SaveChanges();
            }


            //PRINT THE STUDENTS 
            List<Student> students = new List<Student>() { student1, student2, student3 };
            foreach (var student in students)
            {
                PrintStudent(student);
            }
        }

        public static void PrintStudent(Student s)
        {
            Console.WriteLine(".......................................");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s.ID + " " + s.FirstMidName + " " + s.LastName);
            Console.ResetColor();
            Console.WriteLine("Enrollment(s): ");
            foreach (Enrollment e in s.Enrollments)
            {
                Console.WriteLine("\tEnrollment ID: " + e.EnrollmentID + " (" + e.EnrollmentName + ")" +
                    Environment.NewLine + "\tEnrollment Grade: " + e.Grade);
                Console.WriteLine("\t" + e.Course.CourseID + " " + e.Course.CourseName + " " + e.Course.Credits + " points");
                Console.WriteLine();
            }
            Console.WriteLine(".......................................");
        }

        public static void SearchStudentWithInclude(string firstmidname, EducationalContext context)
        {

            if (context.Students.Where(s => s.FirstMidName == firstmidname).FirstOrDefault() == null)
                Console.WriteLine("No student found");
            else
            {
                Student student = context.Students
                    .Where(s => s.FirstMidName == firstmidname)
                    .Include(x => x.Enrollments.Select(c => c.Course))
                    .FirstOrDefault();

                PrintStudent(student);
            }
        }

        public static void SearchStudentWithEntry(string firstmidname, EducationalContext context)
        {

            if (context.Students.Where(s => s.FirstMidName == firstmidname).FirstOrDefault() == null)
                Console.WriteLine("No student found");
            else
            {
                Student student = context.Students
                    .Where(s => s.FirstMidName == firstmidname)
                    .FirstOrDefault();

                context.Entry(student).Collection(e => e.Enrollments).Load();
                PrintStudent(student);
            }
        }

        public static void PrintAllStudentsWithInclude(EducationalContext context)
        {
            try
            {
                foreach (var s in context.Students.Include(x => x.Enrollments.Select(c => c.Course)))
                {
                    PrintStudent(s);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("message: " + e.Message);
                Console.WriteLine("inner exception messag: " + e.InnerException.Message);
            }
        }

        public static void PrintAllStudentsWithEntry(EducationalContext context)
        {
            try
            {
                List<Student> students = context.Students.ToList();

                foreach (Student s in students)
                {
                    context.Entry(s).Collection(e=>e.Enrollments).Load();
                    PrintStudent(s);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("message: " + e.Message);
                Console.WriteLine("inner exception messag: " + e.InnerException.Message);
            }
        }
    }
}