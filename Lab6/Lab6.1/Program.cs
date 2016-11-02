using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Course EntityFrameworkCourse = new Course() { CourseID = 101, CourseName = "Entity Framework", Credits = 50 };
            Course DotNetFrameworkCourse= new Course() { CourseID = 102, CourseName = ".NET Framework", Credits = 50 };
            Course JavascriptCourse = new Course() { CourseID = 103, CourseName = "Javascript", Credits = 50 };

            Course HttpCourse = new Course() { CourseID = 121, CourseName = "Http", Credits = 100 };
            Course SecurityManagementCourse = new Course() { CourseID = 122, CourseName = "Security Management", Credits = 50};


            #region student initialization
            Student s1 = new Student() { FirstMidName = "Ivan", LastName = "Prgomet", ID = 1, EnrollmentDate = new DateTime(2015, 12, 24) };
            s1.Enrollments = new List<Enrollment>
            {
                /*
                    three different courses on the enrollment of 'webdeveloper within .NET'
                */
                new Enrollment() {
                    EnrollmentID =1,
                    EnrollmentName ="Webdeveloper within .NET",
                    Course = EntityFrameworkCourse,
                    Grade ="A-F" },
                new Enrollment() {
                    EnrollmentID =1,
                    EnrollmentName ="Webdeveloper within .NET",
                    Course = DotNetFrameworkCourse,
                    Grade ="A-F" },
                new Enrollment() {
                    EnrollmentID =1,
                    EnrollmentName ="Webdeveloper within .NET",
                    Course = JavascriptCourse,
                    Grade ="A-F" },
            };
            Student s2 = new Student() { FirstMidName = "Lea", LastName = "Winchester", ID = 2, EnrollmentDate = new DateTime(2015, 12, 24) };
            s2.Enrollments = new List<Enrollment>
            {
                new Enrollment() {
                    EnrollmentID =1,
                    EnrollmentName ="Webdeveloper within .NET",
                    Course = EntityFrameworkCourse,
                    Grade ="A-F" },
                new Enrollment() {
                    EnrollmentID =1,
                    EnrollmentName ="Webdeveloper within .NET",
                    Course = DotNetFrameworkCourse,
                    Grade ="A-F" },
                new Enrollment() {
                    EnrollmentID =1,
                    EnrollmentName ="Webdeveloper within .NET",
                    Course = JavascriptCourse,
                    Grade ="A-F" },
            };
            Student s3 = new Student() { FirstMidName = "Jason", LastName = "Bourne", ID = 3, EnrollmentDate = new DateTime(2016, 12, 24) };
            s3.Enrollments = new List<Enrollment>
            {
                new Enrollment() {
                    EnrollmentID =1,
                    EnrollmentName ="Network Security",
                    Course = HttpCourse,
                    Grade ="A,F" },
                new Enrollment() {
                    EnrollmentID =1,
                    EnrollmentName ="Network Security",
                    Course = SecurityManagementCourse,
                    Grade ="A-C" },
            }; 
            #endregion

            List<Student> Students = new List<Student>()
            {
                s1,s2,s3
            };

            foreach (var s in Students)
            {
                PrintStudent(s);
            }




        }
        public static void PrintStudent(Student s)
        {
            Console.WriteLine(".......................................");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s.ID+" "+ s.FirstMidName+" "+s.LastName);
            Console.ResetColor();
            Console.WriteLine("Enrollment(s): ");
            foreach (var e in s.Enrollments)
            {
                Console.WriteLine("\tEnrollment ID: "+e.EnrollmentID+" ("+e.EnrollmentName+")"+
                    Environment.NewLine+ "\tEnrollment Grade: " + e.Grade);
                Console.WriteLine("\t" + e.Course.CourseID+" "+e.Course.CourseName+" "+e.Course.Credits+" points");
                Console.WriteLine();
            }
            Console.WriteLine(".......................................");
        }
    }
}
