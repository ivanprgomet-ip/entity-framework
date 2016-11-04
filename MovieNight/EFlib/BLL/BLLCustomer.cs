using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFlib.BLL
{
    public class BLLCustomer
    {
        static MovieRentalContext _context = new MovieRentalContext();


        public static bool RegisterNewCustomer(Customer newCustomer)
        {
            try
            {
                _context.Customers.Add(newCustomer);
                _context.Database.Log = Console.WriteLine;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static List<Customer> ReturnAllCustomers()
        {
            List<Customer> customers = _context.Customers.ToList();
            return customers;
        }

        public static Customer ReturnCustomerWithID(int customerThatsHiringID)
        {
            return _context.Customers.Find(customerThatsHiringID);
        }
    }
}
