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
        static bool userQuit = false;
        static System.Threading.Thread CheckForLateMovies;

        static void Main(string[] args)
        {

            CheckForLateMovies = new System.Threading.Thread(delegate ()
                {
                    while (true)
                    {
                        System.Threading.Thread.Sleep(10000);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        BLLRentedMovie.CheckForLateMovies();
                        Console.ResetColor();
                    }
                });
            //CheckForLateMovies.Start();

            System.Threading.Thread Main = new System.Threading.Thread(delegate ()
                {
                    while (true)
                    {
                        Run();
                        if (userQuit)
                            break;
                    }
                });
            Main.Start();
        }

        public static void Run()
        {
            Console.WriteLine("1. Print all Customers");
            Console.WriteLine("2. Register new customer");
            Console.WriteLine("3. Print movies (and currently hired movies)");
            Console.WriteLine("4. Hire Movie");
            Console.WriteLine("5. Return Movie");
            Console.WriteLine("6. Register New Movie");
            Console.WriteLine("e. Exit application");
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
                    #region retrieve availabla movies to hire
                    List<Movie> availableMovies = BLLMovie.ReturnAvailableMovies();//TODO: returning movies that should not be available
                    Console.WriteLine("Currently available movies: ");
                    foreach (var m in availableMovies)
                    {
                        Console.WriteLine(m.MovieId + " " + m.MovieName);
                    }
                    Console.WriteLine("Choose which movie to hire >> ");
                    int movieToBeHiredID = int.Parse(Console.ReadLine());
                    Movie movieToBeHired = BLLMovie.ReturnMovieWithID(movieToBeHiredID);

                    Console.WriteLine(movieToBeHired.MovieName + " (" + movieToBeHired.Genre.GenreName + ") was choosen");
                    Console.WriteLine();
                    #endregion

                    #region choose who will hire the movie
                    List<Customer> customers = BLLCustomer.ReturnAllCustomers();
                    foreach (var c in customers)
                    {
                        Console.WriteLine(c.CustomerID + " " + c.CustomerName);
                    }
                    Console.Write("Who is going to make the hire >> ");
                    int customerThatsHiringID = int.Parse(Console.ReadLine());
                    Customer customerThatsHiring = BLLCustomer.ReturnCustomerWithID(customerThatsHiringID);
                    #endregion

                    BLLRentedMovie.HireMovie(customerThatsHiring, movieToBeHired);

                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "5":
                    List<RentedMovie> rentals = BLLRentedMovie.GetRentedMovies();//todo: 
                    foreach (var rental in rentals)
                    {
                        Console.WriteLine(rental.RentedID + " " + rental.Movie.MovieName + " HIRED BY: " + rental.Customer.CustomerName);
                    }
                    Console.Write("Which movie do you wish to return? >> ");
                    int rentIDToReturn = int.Parse(Console.ReadLine());
                    bool returnSuccessfull = BLLRentedMovie.RemoveRentedMovie(rentIDToReturn);
                    Console.WriteLine(returnSuccessfull ? "movie returned successfully" : "movie was not returned");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "6":
                    RegisterNewMovie();
                    break;
                case "e":
                    userQuit = true;
                    Console.Clear();
                    Console.WriteLine("Goodbye...");
                    break;
                default:
                    Console.WriteLine("Please enter a valid command");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }

        private static void RegisterNewMovie()
        {
            Console.Write("Enter movietitle >> ");
            string movieTitle = Console.ReadLine();
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
                Console.WriteLine($"{rentedMovie.Movie.MovieName.ToUpper()} is currently with {rentedMovie.Customer.CustomerName.ToUpper()} \nLast day of return: {rentedMovie.ReturnDate.ToString("dd.MM.yyyy")}");
                Console.WriteLine();
            }
            Console.WriteLine("...............");
        }

        private static void RegisterNewCustomer()
        {
            Console.WriteLine("Enter name >> ");
            string customername = Console.ReadLine();
            Console.WriteLine("Enter address >> ");
            string customeraddress = Console.ReadLine();
            Console.WriteLine("Enter phone >> ");
            string customerphone = Console.ReadLine();

            bool success = BLLCustomer.RegisterNewCustomer(new Customer(customername, customeraddress, customerphone));
            Console.WriteLine(success ? $"Customer {customername} Registered" : "Customer Registration Failed");
        }
        private static void PrintCustomers()
        {
            List<Customer> customers = BLLCustomer.ReturnAllCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.CustomerID + " " + customer.CustomerName + " " + customer.CustomerAdress + " " + customer.CustomerPhone);
            }
        }

    }
}
