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

            while (true)
            {
                Run();
            }



            //RegisterNewCustomer();
            PrintCustomers();
            //RegisterNewMovie();
            //MarkMovieAsRented();
            //MarkMovieAsReturned();
            //CheckForLateMovies();
        }

        public static void Run()
        {
            Console.WriteLine("1. Print all Customers");
            Console.WriteLine("2. Register new customer");
            Console.WriteLine("3. Print movies (and currently hired movies)");
            Console.WriteLine("4. Hire Movie");
            Console.WriteLine("5. Return Movie");
            Console.WriteLine("6. Register New Movie");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PrintCustomers();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                    RegisterNewCustomer();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    PrintMovies();
                    PrintRentedMovies();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "4":

                    //get the available movies only
                    List<Movie> availableMovies = BLLMovie.ReturnAvailableMovies();
                    Console.WriteLine("Currently available movies: ");
                    foreach (var m in availableMovies)
                    {
                        Console.WriteLine(m.MovieId + " " + m.MovieName);
                    }
                    Console.WriteLine("Choose which movie to hire >> ");
                    int movieToBeHiredID = int.Parse(Console.ReadLine());
                    Movie movieToBeHired = BLLMovie.ReturnMovieWithID(movieToBeHiredID);

                    Console.WriteLine(movieToBeHired.MovieName+" ("+movieToBeHired.Genre.GenreName+") was choosen");
                    Console.WriteLine();

                    //choose who is going to hire the movie choosen from the available movies above
                    List<Customer> customers = BLLCustomer.ReturnAllCustomers();
                    foreach (var c in customers)
                    {
                        Console.WriteLine(c.CustomerID + " " + c.CustomerName);
                    }
                    Console.Write("Who is going to make the hire >> ");
                    int customerThatsHiringID = int.Parse(Console.ReadLine());
                    Customer customerThatsHiring = BLLCustomer.ReturnCustomerWithID(customerThatsHiringID);


                    //the actual renting of the movie
                    RentedMovie newRentedMovie = new RentedMovie()
                    {
                        Customer = customerThatsHiring,
                        Movie = movieToBeHired,
                        ReturnDate = new DateTime(2999, 01, 01),
                    };
                    BLLRentedMovie.AddNewRentedMovie(newRentedMovie);//todo: fix this method. something wrong with the context

                    Console.WriteLine(customerThatsHiring.CustomerName + " hired " + movieToBeHired.MovieName+ ". Return date : "+newRentedMovie.ReturnDate.ToString());
                    Console.WriteLine();

                    //BLLCustomer.HireMovieAs(CustomerThatsHiring,MovieToBeHired)
                    //BLLRentedMovie.AddNewRentedMovie()
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "5":
                    //return movie

                    //get all people that have hired a movie
                    //choose one of the persons 
                    //show all moves hired by the person chosen
                    //choose which movie to return
                    //remove the rented movie from rentedmovie
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "6":
                    RegisterNewMovie();
                    break;
                default:
                    Console.WriteLine("App is closing...");
                    break;
            }
        }

        private static void RegisterNewMovie()
        {
            Console.Write("Enter movietitle >> ");
            string movieTitle= Console.ReadLine();
            Console.Write("Enter moviedirector >> ");
            string movieDirector = Console.ReadLine();
            Console.Write("Enter genre with first letter uppercase >> ");
            string movieGenre = Console.ReadLine();

            Genre currentGenre = new Genre() { GenreName = movieGenre };

            Movie newMovie = new Movie() { Genre = currentGenre, MovieDirector = movieDirector, MovieName = movieTitle };
            bool success = BLLMovie.RegisterNewMovie(newMovie);
            Console.WriteLine(success ? $"Movie {newMovie} Registered" : "Movie Registration Failed");
        }
        private static void PrintMovies()
        {
            List<Movie> movies = BLLMovie.ReturnAllMovies();
            Console.WriteLine("*Movies");
            Console.WriteLine();
            foreach (var movie in movies)
            {
                Console.WriteLine($"{movie.MovieName} \n{movie.MovieDirector} \n{movie.Genre.GenreName}");
                Console.WriteLine();
            }
            Console.WriteLine("...............");
        }
        private static void PrintRentedMovies()
        {
            List<RentedMovie> rentedMovies = BLLRentedMovie.ReturnAllRentedMovies();
            Console.WriteLine("*Rented Movies");
            Console.WriteLine();
            foreach (var rentedMovie in rentedMovies)
            {
                Console.WriteLine($"{rentedMovie.Movie.MovieName.ToUpper()} is currently with {rentedMovie.Customer.CustomerName.ToUpper()}");
                Console.WriteLine();
            }
            Console.WriteLine("...............");
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
            Console.WriteLine(success?$"Customer {customername} Registered":"Customer Registration Failed");
        }
        private static void PrintCustomers()
        {
            List<Customer> customers = BLLCustomer.ReturnAllCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.CustomerName+" "+customer.CustomerAdress+" "+customer.CustomerPhone);
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




    }
}
