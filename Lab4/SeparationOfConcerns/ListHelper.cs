using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeparationOfConcerns
{
    /// <summary>
    /// all logic for the retrieval of data.
    /// </summary>
    class ListHelper
    {
        public List<Employee> emps { get; set; }

        public ListHelper()
        {
            //init the fictional database..
            emps = new List<Employee>()
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
        }

        public List<Employee> ReturnOrderedEmployeesLastname()
        {
            //EmployeeSortByLastname customerSortByLastname
            //List<Employee> ordered = emps = new List<Employee>();
            //emps.Sort(customerSortByLastname);

            List<Employee> ordered = emps.OrderBy(e => e.Lastname).ToList();//order by lastname and place in new list
            return ordered;
        }
        public List<Employee> ReturnOrderedEmployeesFirstname()
        {
            List<Employee> ordered = emps.OrderBy(e => e.Firstname).ToList();//order by lastname and place in new list
            return ordered;
        }
    }
}
