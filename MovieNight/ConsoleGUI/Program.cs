using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EFlib;
using EFlib.BLL;

namespace ConsoleGUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //MovieRentalContext ctx = new MovieRentalContext();

            Run();



            //RegisterNewCustomer();
            PrintAllCustomers();
            //RegisterNewMovie();
            //MarkMovieAsRented();
            //MarkMovieAsReturned();
            //CheckForLateMovies();
        }

        public static void Run()
        {
            Console.WriteLine("1. Print all Customers");
            Console.WriteLine("2. Register new customer");
            Console.WriteLine("3. Print movies and statuses (hired and returned)");
            Console.WriteLine("4. Hire Movie");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PrintAllCustomers();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                   
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                   
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "4":
                   
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("App is closing...");
                    break;
            }
        }







        private static void PrintAllCustomers()
        {
            List<Customer> customers = BLLCustomer.ReturnAllCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.CustomerName);
            }
        }

        private static void CheckForLateMovies()
        {
            throw new NotImplementedException();
        }

        private static void MarkMovieAsReturned()
        {
            throw new NotImplementedException();
        }

        private static void MarkMovieAsRented()
        {
            throw new NotImplementedException();
        }

        private static void RegisterNewMovie()
        {
            throw new NotImplementedException();
        }

        private static void RegisterNewCustomer()
        {
            Console.WriteLine("Enter name >> ");
            string customername = Console.ReadLine();
            Console.WriteLine("Enter address >> ");
            string customeraddress= Console.ReadLine();
            Console.WriteLine("Enter phone >> ");
            string customerphone= Console.ReadLine();

            bool success = BLLCustomer.RegisterNewCustomer(new Customer(customername, customeraddress, customerphone));
            Console.WriteLine(success?"Customer Registered":"Customer Registration Failed");
        }
    }
}
