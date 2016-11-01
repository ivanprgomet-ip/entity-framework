using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex01
{

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
            Type[] types = GetTypesFromExecutingAssembly();
            IEnumerable<string> typesQuery = from t
                                             in types
                                             where t.IsPublic
                                             select t.FullName;
            foreach (var t in typesQuery)
            {
                Console.WriteLine(t);
            }

            //EX04


        }
        public static Type[] GetTypesFromExecutingAssembly()
        {
            return Assembly.GetExecutingAssembly().GetTypes();
        }
    }
}
