using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01
{
    class Program
    {
        public static List<Employee> employees = new List<Employee>();
        public static IEnumerable<Employee> query = from e
                                                    in employees
                                                    where e.hiredate < new DateTime(2016,01,01)
                                                    orderby e.name
                                                    select e;

        static void Main(string[] args)
        {
            employees.Add(new Employee()
            {
                id = 1,
                name = "tom",
                hiredate = new DateTime(2009, 03, 20)
            });
            employees.Add(new Employee()
            {
                id = 2,
                name = "lisa",
                hiredate = new DateTime(2016, 03, 20)
            });
            employees.Add(new Employee()
            {
                id = 3,
                name = "cindy",
                hiredate = new DateTime(2009, 03, 20)
            });
            employees.Add(new Employee()
            {
                id = 4,
                name = "stewart",
                hiredate = new DateTime(2010, 03, 20)
            });
            employees.Add(new Employee()
            {
                id = 5,
                name = "mark",
                hiredate = new DateTime(2016, 03, 20)
            });


            foreach(Employee e in query)
            {
                Console.WriteLine(e.name);
            };


        }
    }
}
