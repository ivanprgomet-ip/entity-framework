using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Ex01
{
    //declare
    public delegate bool FindNemoPredicate(Employee e);

    public class Sample { /*sample for exercise 03*/}
    public class Program
    {
        static void Main(string[] args)
        {
            //EX01
            //List<Employee> emps = Employee.GenerateEmployees();
            //IEnumerable<Employee> query = from e
            //                              in emps
            //                              where e.hiredate < new DateTime(2016, 01, 01)
            //                              orderby e.name
            //                              select e;
            ////must ToList() the query because foreach only supports lists
            //query.ToList().ForEach(e => Console.WriteLine(e.name));

            //EX02
            //int currentID = emps.Count + 1;

            //Console.WriteLine("Before: ");
            //emps.ForEach(e => Console.WriteLine(e.id + " " + e.name));

            //emps.Add(new Employee() { id = currentID, name = "emp" + currentID, hiredate = new DateTime(2016, 10, 05) });

            //Console.WriteLine("After: ");
            //emps.ForEach(e => Console.WriteLine(e.id + " " + e.name));


            //EX03
            //Type[] types = GetTypesFromExecutingAssembly();
            //IEnumerable<string> typesQuery = from t
            //                                 in types
            //                                 where t.IsPublic
            //                                 select t.FullName;
            //foreach (var t in typesQuery)
            //{
            //    Console.WriteLine(t);
            //}

            //EX04 & EX05
            //SaveCurrentlyRunningProcesses("processes.xml");

            //EX06
            //I din Main metod skapa upp en array av Employee den måste innehålla minst fyra olika objekt av typen Employee.
            
            Employee[] employeeArray = Employee.GenerateEmployees().ToArray();
            Console.WriteLine(SearchArrayForNemo(employeeArray, NemoExists));

        }
        public static Type[] GetTypesFromExecutingAssembly()
        {
            return Assembly.GetExecutingAssembly().GetTypes();
        }
        public static void SaveCurrentlyRunningProcesses(string filename)
        {
            var query = from p in Process.GetProcesses()
                        orderby p.ProcessName ascending
                        select
                            new XElement("process",
                                new XAttribute("Name", p.ProcessName),
                                new XAttribute("PID", p.Id));
            XElement xmlDoc = new XElement("processes", query);

            xmlDoc.Save(filename);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("successfully saved currently running processes into " + filename);
            Console.ResetColor();

            //Console.WriteLine(xmlDoc);//print xml document

            IEnumerable<int> ids = from e
                                   in xmlDoc.Descendants()
                                   where e.Attribute("Name").Value == "devenv"
                                   orderby (int)e.Attribute("PID")
                                   select (int)e.Attribute("PID");

            //prints the unique process id(s) of the visual studio instances
            ids.ToList().ForEach(e => Console.WriteLine(e));
        }

        public static bool NemoExists(Employee e)
        {
                if (e.name == "nemo")
                    return true;
                else
                    return false;
        }
        public static string SearchArrayForNemo(Employee[] emps, FindNemoPredicate nemoExists)
        {
            foreach (var e in emps)
            {
                if (nemoExists(e))
                    return e.name;
            }
            return "not found";
        }
    }
}