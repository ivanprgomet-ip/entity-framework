using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeparationOfConcerns
{
    /// <summary>
    /// all the UI for the application. no logic zone.
    /// </summary>
    class Application
    {
        ListHelper db { get; set; }
        public Application()
        {
            db = new ListHelper();
        }

      

        public bool isRunning = true;

        public void Run()
        {
            Console.WriteLine("1. alla namn sorterade efter efternamn");
            Console.WriteLine("2. alla namn sorterade efter förnamn");
            Console.WriteLine("3. lista alla anställda för avdelning... ");
            Console.WriteLine("4. fritext sökning");
            Console.WriteLine("5. lista anställda som varit anställda mindre än 1 år");
            Console.WriteLine("6. lista anställd från någon avdelning");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    List<Employee> orderedByLastname = db.ReturnOrderedEmployeesLastname();
                    foreach (var emp in orderedByLastname)//iterate over ordered list
                    {
                        Console.WriteLine(emp.Firstname + " " + emp.Lastname);
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                    List<Employee> orderedByFirstname = db.ReturnOrderedEmployeesFirstname();
                    foreach (var emp in orderedByFirstname)//iterate over ordered list
                    {
                        Console.WriteLine(emp.Firstname + " " + emp.Lastname);
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    Console.WriteLine("1. administration");
                    Console.WriteLine("2. InformationTechnology");
                    Console.WriteLine("3. Support");
                    Console.WriteLine("4. Marketing");
                    Console.WriteLine("5. Economics");
                    int dep = Convert.ToInt32(Console.ReadLine());

                    //return employees with specific department
                    List<Employee> employees = db.ReturnEmployeesFromDepartment(dep);
                    foreach (var emp in employees)
                    {
                        Console.WriteLine(emp.Firstname + " " + emp.Lastname + " " + emp.EmpDepartment);
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                //case "4":
                //    Console.WriteLine("Ange söktext >> ");
                //    string freeSearch = Console.ReadLine();

                //    List<Employee> freeSearched = emps.Where(e => e.Firstname.StartsWith(freeSearch[0].ToString())
                //                                                || e.Firstname.Contains(freeSearch)
                //                                                || e.Lastname.StartsWith(freeSearch[0].ToString())
                //                                                || e.Lastname.Contains(freeSearch)).ToList();

                //    foreach (var emp in freeSearched)
                //    {
                //        Console.WriteLine(emp.Firstname + " " + emp.Lastname + " " + emp.Age + " " + emp.HireDate.ToShortDateString());
                //    }
                //    Console.ReadKey();
                //    Console.Clear();
                //    break;
                //case "5":
                //    //code for employees that have been hired less than a year
                //    DateTime today = DateTime.Today;
                //    List<Employee> hiredLessThanAYear = emps.Where(e => (today - e.HireDate).Days < 365).ToList();
                //    foreach (var emp in hiredLessThanAYear)
                //    {
                //        if (emp.HireDate > today)
                //            Console.WriteLine(emp.Firstname + " " + emp.Lastname + " cant be hired before being hired (hiredate? " + emp.HireDate.ToShortDateString() + ")");
                //        else
                //            Console.WriteLine(emp.Firstname + " " + emp.Lastname + " " + emp.HireDate.ToShortDateString());
                //    }
                //    Console.ReadKey();
                //    Console.Clear();
                //    break;
                //case "6":
                //    Random rnd = new Random();
                //    int DepartmentCount = Enum.GetNames(typeof(Department)).Length;
                //    int rndDepIndex = rnd.Next(1, DepartmentCount) + 1;
                //    Employee first = emps.Where(e => e.EmpDepartment == (Department)rndDepIndex).First();
                //    Console.WriteLine(first.Firstname + " " + first.Lastname + " " + first.EmpDepartment);
                //    break;
                default:
                    Console.WriteLine("App is closing...");
                    isRunning = false;
                    break;
            }
        }
    }
}
