using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._1_3_
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<EducationContext>());
            GenerateStudents();

            using (EducationContext context = new EducationContext())
            {
                foreach (var student in context.Students.Include(e => e.Enrollments.Select(c=>c.Course)).ToList())
                {
                    Console.WriteLine(student.FirstMidName + " " + student.LastName + "\nEnrolled to: ");

                    foreach (var enrollment in student.Enrollments)
                    {
                        Console.WriteLine("\t"+enrollment.EnrollmentID+"# "+ enrollment.EnrollmentName+" "+enrollment.Grade);
                        Console.WriteLine("\t"+enrollment.Course.CourseID+" "+ enrollment.Course.CourseName+" ("+enrollment.Course.Credits+"p) ");//todo: not working
                    }

                    Console.WriteLine("......................");
                    Console.WriteLine();
                }
            }
            Console.ResetColor();
        }
        public static void GenerateStudents()
        {
            Course course1 = new Course() { CourseName = "Entity Framework", Credits = 50 };
            Course course2 = new Course() { CourseName = ".NET Framework", Credits = 50 };
            Course course3 = new Course() { CourseName = "Javascript", Credits = 50 };
            Course course4 = new Course() { CourseName = "Basic Algorithms", Credits = 50 };

            Course course5 = new Course() { CourseName = "Http", Credits = 100 };
            Course course6 = new Course() { CourseName = "Security Management", Credits = 50 };

            Enrollment LWEF001 = new Enrollment() { Course = course1, EnrollmentName = "EF2398lw", Grade = "A-F" };
            Enrollment LWNET01 = new Enrollment() { Course = course2, EnrollmentName = "NET294lw", Grade = "A-F" };
            Enrollment LWJS01= new Enrollment() { Course = course3, EnrollmentName = "JS233lw", Grade = "A-F" };
            Enrollment LWBA01 = new Enrollment() { Course = course4, EnrollmentName = "BA23864lw", Grade = "A-F" };

            Enrollment IPEF001 = new Enrollment() { Course = course1, EnrollmentName = "EF2398ip", Grade = "A-F" };
            Enrollment IPNET01 = new Enrollment() { Course = course2, EnrollmentName = "NET294ip", Grade = "A-F" };
            Enrollment IPJS01 = new Enrollment() { Course = course3, EnrollmentName = "JS233ip", Grade = "A-F" };
            Enrollment IPBA01 = new Enrollment() { Course = course4, EnrollmentName = "BA23864ip", Grade = "A-F" };

            Enrollment JBHP01 = new Enrollment() { Course = course5, EnrollmentName = "HP23864jb", Grade = "A-F" };
            Enrollment JBSM01 = new Enrollment() { Course = course6, EnrollmentName = "SM23864jb", Grade = "A-F" };

            Student student1 = new Student()
            {
                FirstMidName = "Ivan",
                LastName = "Prgomet",
                EnrollmentDate = new DateTime(2015, 12, 24),
                Enrollments = new HashSet<Enrollment>()
                {
                    IPEF001, IPNET01,IPJS01 ,IPBA01
                }
            };
            Student student2 = new Student()
            {
                FirstMidName = "Lea",
                LastName = "Winchester",
                EnrollmentDate = new DateTime(2015, 12, 24),
                Enrollments = new HashSet<Enrollment>()
                {
                    LWEF001,LWNET01,LWJS01,LWBA01
                }
            };
            Student student3 = new Student()
            {
                FirstMidName = "Jason",
                LastName = "Bourne",
                EnrollmentDate = new DateTime(2015, 12, 24),
                Enrollments = new HashSet<Enrollment>()
                {
                    JBHP01,JBSM01
                }
            };

            using (EducationContext context = new EducationContext())
            {
                context.Students.Add(student3);
                context.Students.Add(student2);
                context.Students.Add(student1);
                context.Database.Log = Console.WriteLine;
                context.SaveChanges();
            }
        }
    }
}
