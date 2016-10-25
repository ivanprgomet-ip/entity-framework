using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeparationOfConcerns
{
    class EmployeeSortByLastname : IComparer<Employee>
    {
        public int Compare(Employee left, Employee right)
        {
            return left.Lastname.CompareTo(right.Lastname);
        }

        //public int Compare(object left, object right)
        //{
        //    Employee e1 = left as Employee;
        //    Employee e2 = right as Employee;

        //    return e1.Lastname.CompareTo(e2.Lastname);
        //}
    }
}
