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

            #region explanation 01
            /*
                the code below doesnt have any include methods or entry loads. 
                to work, the code below requires lazy loading. this means set the 
                navigation properties in the relevant classes to virtual. when they are
                virtual, you should also not have any initialization of code in the constructors.
                If you dont have the navigation properties set to virtual, and you have the 
                navigation properties initialized in the constructor, the code will not chrash, 
                but it also wont display any data.

                setting the lazyloadingenabled property to false is just another way of 
                removing all the virtual keyword from the navigation properties in the classes.
                it will crash. but if you have lazyloadingenabled property to false, and the 
                navigation properties to virtual, one way to avoid a crash is to also initialize the
                properties in the constructor, which will dodge the nullreference exception.
            */
            #endregion
            #region code 01
            //using (EducationContext context = new EducationContext())
            //{
            //    //context.Configuration.LazyLoadingEnabled = false;

            //    foreach (var student in context.Students)
            //    {
            //        Console.WriteLine(student.FirstMidName + " " + student.LastName + "\nEnrolled to: ");

            //        foreach (var enrollment in student.Enrollments)
            //        {
            //            Console.WriteLine("\t" + enrollment.EnrollmentID + ": " + enrollment.EnrollmentName + " " + enrollment.Grade+" " +enrollment.status);
            //            Console.WriteLine("\t" + enrollment.Course.CourseID + ": " + enrollment.Course.CourseName + " (" + enrollment.Course.Credits + "p) ");
            //            Console.WriteLine();
            //        }

            //        Console.WriteLine("......................");
            //        Console.WriteLine();
            //    }
            //} 
            #endregion

            #region explanation 02
            /*
                   the code below has got includes for all the associated data for a student, so in the classes, no 
                   virtual keyword is required for the navigation properties. No initialization is required neither, but wont
                   make any diference if you initialize the navigation properties in the constructor. 
               */
            #endregion
            #region code 02
            using (EducationContext context = new EducationContext())
            {
                foreach (var student in context.Students.Include(e => e.Enrollments.Select(c => c.Course)).ToList())
                {
                    Console.WriteLine(student.FirstMidName + " " + student.LastName + "\nEnrolled to: ");

                    foreach (var enrollment in student.Enrollments)
                    {
                        Console.ForegroundColor = ReturnEnrollmentStatusColor(enrollment);
                        Console.WriteLine("\t" + enrollment.EnrollmentID + ": " + enrollment.EnrollmentName + " " + enrollment.Grade +" " +enrollment.status);
                        Console.WriteLine("\t" + enrollment.Course.CourseID + ": " + enrollment.Course.CourseName + " (" + enrollment.Course.Credits + "p) ");
                        Console.WriteLine();
                        Console.ResetColor();
                    }

                    Console.WriteLine("......................");
                    Console.WriteLine();
                }
            } 
            #endregion
        }
        public static void GenerateStudents()
        {
            Course course1 = new Course() { CourseName = "Entity Framework", Credits = 50 };
            Course course2 = new Course() { CourseName = ".NET Framework", Credits = 50 };
            Course course3 = new Course() { CourseName = "Javascript", Credits = 50 };
            Course course4 = new Course() { CourseName = "Basic Algorithms", Credits = 50 };

            Course course5 = new Course() { CourseName = "Http", Credits = 100 };
            Course course6 = new Course() { CourseName = "Security Management", Credits = 50 };

            Enrollment LWEF001 = new Enrollment() { Course = course1, EnrollmentName = "EF2398lw", Grade = "A-F",status=EnrollmentStatus.Approved };
            Enrollment LWNET01 = new Enrollment() { Course = course2, EnrollmentName = "NET294lw", Grade = "A-F", status = EnrollmentStatus.Waiting };
            Enrollment LWJS01 = new Enrollment() { Course = course3, EnrollmentName = "JS233lw", Grade = "A-F", status = EnrollmentStatus.Approved };
            Enrollment LWBA01 = new Enrollment() { Course = course4, EnrollmentName = "BA23864lw", Grade = "A-F", status = EnrollmentStatus.Approved };

            Enrollment IPEF001 = new Enrollment() { Course = course1, EnrollmentName = "EF2398ip", Grade = "A-F", status = EnrollmentStatus.Waiting };
            Enrollment IPNET01 = new Enrollment() { Course = course2, EnrollmentName = "NET294ip", Grade = "A-F", status = EnrollmentStatus.Waiting };
            Enrollment IPJS01 = new Enrollment() { Course = course3, EnrollmentName = "JS233ip", Grade = "A-F", status = EnrollmentStatus.Waiting };
            Enrollment IPBA01 = new Enrollment() { Course = course4, EnrollmentName = "BA23864ip", Grade = "A-F", status = EnrollmentStatus.Waiting };

            Enrollment JBHP01 = new Enrollment() { Course = course5, EnrollmentName = "HP23864jb", Grade = "A-F", status = EnrollmentStatus.Approved};
            Enrollment JBSM01 = new Enrollment() { Course = course6, EnrollmentName = "SM23864jb", Grade = "A-F", status = EnrollmentStatus.Approved };

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
        public static ConsoleColor ReturnEnrollmentStatusColor(Enrollment enrollment)
        {
            switch (enrollment.status)
            {
                case EnrollmentStatus.Waiting:
                    return ConsoleColor.Yellow;
                case EnrollmentStatus.Neglected:
                    return ConsoleColor.Red;
                case EnrollmentStatus.Approved:
                    return ConsoleColor.Green;
                default:
                    return ConsoleColor.DarkYellow;
            }
        }
    }
}
