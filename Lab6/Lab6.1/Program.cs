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
            Course EntityFrameworkCourse = new Course() {CourseName = "Entity Framework", Credits = 50 };
            Course DotNetFrameworkCourse= new Course() {CourseName = ".NET Framework", Credits = 50 };
            Course JavascriptCourse = new Course() {CourseName = "Javascript", Credits = 50 };

            Course HttpCourse = new Course() {CourseName = "Http", Credits = 100 };
            Course SecurityManagementCourse = new Course() {CourseName = "Security Management", Credits = 50};


            #region student initialization
            Student s1 = new Student() { FirstMidName = "Ivan", LastName = "Prgomet",EnrollmentDate = new DateTime(2015, 12, 24) };
            s1.Enrollments = new List<Enrollment>
            {
                /*
                    three different courses on the enrollment of 'webdeveloper within .NET'
                */
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
            Student s2 = new Student() { FirstMidName = "Lea", LastName = "Winchester",EnrollmentDate = new DateTime(2015, 12, 24) };
            s2.Enrollments = new List<Enrollment>
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
            Student s3 = new Student() { FirstMidName = "Jason", LastName = "Bourne",EnrollmentDate = new DateTime(2016, 12, 24) };
            s3.Enrollments = new List<Enrollment>
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
            #endregion

            List<Student> Students = new List<Student>()
            {
                s1,s2,s3
            };

            //foreach (var s in Students)
            //{
            //    PrintStudent(s);
            //}


            using (EducationalContext ectx = new EducationalContext())
            {
                //adding the students will in turn add the enrollments which will in turn add the courses!
                ectx.Students.AddRange(Students);
                ectx.Database.Log = Console.WriteLine;
                ectx.SaveChanges();
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
