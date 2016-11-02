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


            Student s1 = new Student() { FirstMidName = "Ivan", LastName="Prgomet", ID = 1, EnrollmentDate = new DateTime(2015, 12, 24) };
            s1.Enrollments = new List<Enrollment>
            {
                new Enrollment() {EnrollmentID=1,EnrollmentName="enrollment01",CourseID=1, Grade="5" },
                new Enrollment() {EnrollmentID=2,EnrollmentName="enrollment02",CourseID=2, Grade="3" },
            };
            Student s2 = new Student() { FirstMidName = "Lea", LastName = "Winchester", ID = 2, EnrollmentDate = new DateTime(2015, 12, 24) };
            s2.Enrollments = new List<Enrollment>
            {
                new Enrollment() {EnrollmentID=1,EnrollmentName="enrollment01",CourseID=1, Grade="4" },
                new Enrollment() {EnrollmentID=2,EnrollmentName="enrollment02",CourseID=2, Grade="4" },
            };
            Student s3 = new Student() { FirstMidName = "Jason", LastName = "Bourne", ID = 3, EnrollmentDate = new DateTime(2016, 12, 24) };
            s3.Enrollments = new List<Enrollment>
            {
                new Enrollment() {EnrollmentID=1,EnrollmentName="enrollment01",CourseID=1, Grade="4" },
                new Enrollment() {EnrollmentID=3,EnrollmentName="enrollment03",CourseID=3, Grade="5" },
            };


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
                Console.WriteLine("EID: "+e.EnrollmentID+" EName: "+e.EnrollmentName+" CourseID: "+e.CourseID+" Grade: "+e.Grade);
            }
            Console.WriteLine(".......................................");
        }
    }
}
