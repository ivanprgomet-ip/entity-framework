using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    /// <summary>
    /// 3.3	Linq
    /// 3.4 Linq and Lambda combined against simple type list
    /// 3.5 Linq and lambda combined against list of objects
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region exercises 3 and 4

            //List<string> names = new List<string>()
            //{
            //    "amanda","ben","cindy","doug","emil","fredrik","gustav","greta"
            //};

            //while (true)
            //{
            //    Console.WriteLine("[1] visa alla namn");
            //    Console.WriteLine("[2] Visa namn som börjar på... (linq)");
            //    Console.WriteLine("[3] visa alla namn som inte innehåller bokstaven... (lambda)");
            //    Console.WriteLine("[4] visa alla namn som börjar på bokstaven och inte innehåller bokstaven... (lambda)");

            //    string choice = Console.ReadLine();

            //    switch (choice)
            //    {
            //        case "1":
            //            foreach (var name in names)
            //            {
            //                Console.WriteLine(name);
            //            }
            //            Console.ReadKey();
            //            Console.Clear();
            //            break;
            //        case "2":
            //            Console.WriteLine("Bokstav >> ");
            //            string letter = Console.ReadLine();
            //            IEnumerable namesStartingWith = names.Where(n => n.StartsWith(letter));
            //            foreach (var name in namesStartingWith)
            //            {
            //                Console.WriteLine(name);
            //            }
            //            Console.ReadKey();
            //            Console.Clear();
            //            break;
            //        case "3":
            //            //extract names that dont contain the letter...
            //            Console.WriteLine("Bokstav >> ");
            //            string letter2 = Console.ReadLine();
            //            IEnumerable namesWithoutS = names.Where(n => !n.Contains(letter2));
            //            foreach (var name in namesWithoutS)
            //            {
            //                Console.WriteLine(name);
            //            }
            //            Console.ReadKey();
            //            Console.Clear();
            //            break;
            //        case "4":
            //            Console.WriteLine("Som börjar på  bokstaven >> ");
            //            string startingLetter = Console.ReadLine();
            //            Console.WriteLine("Som inte innehåller bokstaven >> ");
            //            string doesntContainLetter = Console.ReadLine();

            //            IEnumerable namesCollection = names.Where(n => n.StartsWith(startingLetter) && !n.Contains(doesntContainLetter));
            //            foreach (var name in namesCollection)
            //            {
            //                Console.WriteLine(name);
            //            }
            //            Console.ReadKey();
            //            Console.Clear();
            //            break;
            //        default:
            //            Console.WriteLine("Please enter legit input");
            //            break;
            //    }
            //}
            #endregion


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

            while (true)
            {
                Console.WriteLine("1. alla namn sorterade efter efternamn");
                Console.WriteLine("2. alla namn sorterade efter förnamn");
                Console.WriteLine("3. lista alla anställda för avdelning... ");
                Console.WriteLine("4. fritext sökning");
                Console.WriteLine("5. lista anställda som varit anställda mindre än 1 år");
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
                            if(emp.HireDate>today)
                                Console.WriteLine(emp.Firstname + " " + emp.Lastname + " cant be hired before being hired (hiredate? "+ emp.HireDate.ToShortDateString()+")");
                            else
                                Console.WriteLine(emp.Firstname + " " + emp.Lastname +" "+ emp.HireDate.ToShortDateString());
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        break;
                }

            }

        }
    }
    public enum Department
    {
        Administration = 1, InformationTechnology, Support, Marketing, Economics
    }
    class Employee
    {

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime HireDate { get; set; }
        public Department EmpDepartment { get; set; }
        public int Age { get; set; }


    }
}
