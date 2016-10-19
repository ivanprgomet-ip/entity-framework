using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            AdventureWorks2014Entities a = new AdventureWorks2014Entities();
            foreach (var employee in a.Employees)
            {
                Console.WriteLine("Fullname: "+employee.Person.FirstName + " " + employee.Person.MiddleName + " " + employee.Person.LastName+" | Marital Status: "+employee.MaritalStatus);
            }
        }
    }
}
