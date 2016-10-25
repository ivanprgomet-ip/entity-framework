using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeparationOfConcerns
{
    class Application
    {
        List<Employee> emps = new List<Employee>()
            {
                new Employee() {Id=1,Firstname="Ivan",Lastname="Prgomet",HireDate=new DateTime(2016,03,20), EmpDepartment=Department.InformationTechnology,Age=24},
                new Employee() {Id=1,Firstname="Doug",Lastname="Floyers",HireDate=new DateTime(2015,10,10), EmpDepartment=Department.Economics,Age=24},
                new Employee() {Id=1,Firstname="Marlon",Lastname="Reeds",HireDate=new DateTime(2015,09,10), EmpDepartment=Department.Support,Age=29},
                new Employee() {Id=1,Firstname="Mark",Lastname="Sergej",HireDate=new DateTime(2015,07,10), EmpDepartment=Department.Support,Age=20},
                new Employee() {Id=1,Firstname="Cindy",Lastname="Logans",HireDate=new DateTime(2016,03,10), EmpDepartment=Department.Administration,Age=34},
                new Employee() {Id=1,Firstname="Ben",Lastname="Afleck",HireDate=new DateTime(2015,09,03), EmpDepartment=Department.Administration,Age=33},
                new Employee() {Id=1,Firstname="Bane",Lastname="Banes",HireDate=new DateTime(2015,09,10), EmpDepartment=Department.InformationTechnology,Age=26},
                new Employee() {Id=1,Firstname="Wayne",Lastname="Enterprise",HireDate=new DateTime(2015,03,10), EmpDepartment=Department.InformationTechnology,Age=40},
                new Employee() {Id=1,Firstname="Garret",Lastname="Green",HireDate=new DateTime(2016,09,10), EmpDepartment=Department.Administration,Age=42},
                new Employee() {Id=1,Firstname="Louisa",Lastname="Stevens",HireDate=new DateTime(2017,05,09), EmpDepartment=Department.Marketing,Age=29},
            };

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
                    foreach (var emp in emps.OrderBy(e => e.Lastname))
                    {
                        Console.WriteLine(emp.Firstname + " " + emp.Lastname);
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                    foreach (var emp in emps.OrderBy(e => e.Firstname))
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

                    #region swithc
                    switch (dep)
                    {
                        case (int)Department.Administration:
                            foreach (var emp in emps.Where(e => e.EmpDepartment == Department.Administration))
                            {
                                Console.WriteLine(emp.Firstname + " " + emp.Lastname + " " + emp.EmpDepartment);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case (int)Department.InformationTechnology:
                            foreach (var emp in emps.Where(e => e.EmpDepartment == Department.InformationTechnology))
                            {
                                Console.WriteLine(emp.Firstname + " " + emp.Lastname + " " + emp.EmpDepartment);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case (int)Department.Support:
                            foreach (var emp in emps.Where(e => e.EmpDepartment == Department.Support))
                            {
                                Console.WriteLine(emp.Firstname + " " + emp.Lastname + " " + emp.EmpDepartment);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case (int)Department.Marketing:
                            foreach (var emp in emps.Where(e => e.EmpDepartment == Department.Marketing))
                            {
                                Console.WriteLine(emp.Firstname + " " + emp.Lastname + " " + emp.EmpDepartment);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case (int)Department.Economics:
                            foreach (var emp in emps.Where(e => e.EmpDepartment == Department.Economics))
                            {
                                Console.WriteLine(emp.Firstname + " " + emp.Lastname + " " + emp.EmpDepartment);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        default:
                            break;
                    }
                    #endregion
                    break;
                case "4":
                    Console.WriteLine("Ange söktext >> ");
                    string freeSearch = Console.ReadLine();

                    List<Employee> freeSearched = emps.Where(e => e.Firstname.StartsWith(freeSearch[0].ToString())
                                                                || e.Firstname.Contains(freeSearch)
                                                                || e.Lastname.StartsWith(freeSearch[0].ToString())
                                                                || e.Lastname.Contains(freeSearch)).ToList();

                    foreach (var emp in freeSearched)
                    {
                        Console.WriteLine(emp.Firstname + " " + emp.Lastname + " " + emp.Age + " " + emp.HireDate.ToShortDateString());
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "5":
                    //code for employees that have been hired less than a year
                    DateTime today = DateTime.Today;
                    List<Employee> hiredLessThanAYear = emps.Where(e => (today - e.HireDate).Days < 365).ToList();
                    foreach (var emp in hiredLessThanAYear)
                    {
                        if (emp.HireDate > today)
                            Console.WriteLine(emp.Firstname + " " + emp.Lastname + " cant be hired before being hired (hiredate? " + emp.HireDate.ToShortDateString() + ")");
                        else
                            Console.WriteLine(emp.Firstname + " " + emp.Lastname + " " + emp.HireDate.ToShortDateString());
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "6":
                    Random rnd = new Random();
                    int DepartmentCount = Enum.GetNames(typeof(Department)).Length;
                    int rndDepIndex = rnd.Next(1, DepartmentCount) + 1;
                    Employee first = emps.Where(e => e.EmpDepartment == (Department)rndDepIndex).First();
                    Console.WriteLine(first.Firstname + " " + first.Lastname + " " + first.EmpDepartment);
                    break;
                default:
                    Console.WriteLine("App is closing...");
                    isRunning = false;
                    break;
            }
        }
    }
}
