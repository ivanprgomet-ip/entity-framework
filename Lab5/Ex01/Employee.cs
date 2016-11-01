using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01
{
    class Employee
    {
        public int id;
        public string name;
        public DateTime hiredate;

        public static List<Employee> GenerateEmployees()
        {
            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee()
            {
                id = employees.Count+1,
                name = "tom",
                hiredate = new DateTime(2009, 03, 20)
            });
            employees.Add(new Employee()
            {
                id = employees.Count + 1,
                name = "lisa",
                hiredate = new DateTime(2016, 03, 20)
            });
            employees.Add(new Employee()
            {
                id = employees.Count + 1,
                name = "cindy",
                hiredate = new DateTime(2009, 03, 20)
            });
            employees.Add(new Employee()
            {
                id = employees.Count + 1,
                name = "stewart",
                hiredate = new DateTime(2010, 03, 20)
            });
            employees.Add(new Employee()
            {
                id = employees.Count + 1,
                name = "mark",
                hiredate = new DateTime(2016, 03, 20)
            });
            employees.Add(new Employee()
            {
                id = employees.Count + 1,
                name = "doug",
                hiredate = new DateTime(2016, 03, 20)
            });

            return employees;
        }
    }
}
