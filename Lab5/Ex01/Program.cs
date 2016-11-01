using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            //exercise 01
            List<Employee> emps = Employee.GenerateEmployees();
            IEnumerable<Employee> query = from e
                                          in emps
                                          where e.hiredate < new DateTime(2016, 01, 01)
                                          orderby e.name
                                          select e;
            //must ToList() the query because foreach only supports lists
            query.ToList().ForEach(e => Console.WriteLine(e.name));



        }
    }
}
