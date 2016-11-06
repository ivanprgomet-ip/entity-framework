using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace EFlib.BLL
{
    public class BLLRentedMovie
    {
        static MovieRentalContext _context = new MovieRentalContext();

        public static List<RentedMovie> ReturnAllRentedMovies()
        {
            List<RentedMovie> rentedMovies = _context.RentedMovies
                .Include(c => c.Movie)
                .Include(c => c.Customer)
                .ToList();
            return rentedMovies;
        }

        /// <summary>
        /// return a list of all customers that have hired movie(s)
        /// </summary>
        /// <returns></returns>
        public static Dictionary<Customer, List<Movie>> ReturnCustomersWithHiredMovies()
        {
            List<RentedMovie> rentals = ReturnAllRentedMovies();
            Dictionary<Customer, List<Movie>> rentalsDict = new Dictionary<Customer, List<Movie>>();

            foreach (var rentedMovie in rentals)
            {
                List<Movie> currentCustomersMovies = new List<Movie>();

                if (rentalsDict.ContainsKey(rentedMovie.Customer))//the customer already exists in the dictionary, add the movie value to the existent customer
                {
                    currentCustomersMovies.Add(rentedMovie.Movie);
                    rentalsDict[rentedMovie.Customer].Add(rentedMovie.Movie);
                }
                else//else add the customer and also a list for the movie(s) the customer has hired
                {
                    currentCustomersMovies.Add(rentedMovie.Movie);
                    rentalsDict.Add(rentedMovie.Customer, currentCustomersMovies);
                }
            }
            return rentalsDict;
        }

        public static bool RemoveRentedMovie(int rentedMovieID)
        {
            try
            {
                _context.RentedMovies.Remove(_context.RentedMovies.Find(rentedMovieID));

                //_context.RentedMovies.Remove(ReturnRentedMovieForCustomerID(customerID));
                _context.Database.Log = Console.WriteLine;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static RentedMovie ReturnRentedMovieForCustomerID(int customerID)
        {
            return _context.RentedMovies.FirstOrDefault(m => m.Customer.CustomerID==customerID);
        }

        /// <summary>
        /// TODO: THIS METHOD IS TEMPORARY!
        /// </summary>
        /// <param name="customerThatsHiring"></param>
        /// <param name="movieToBeHired"></param>
        /// <returns></returns>
        public static bool HireMovie(Customer customerThatsHiring, Movie movieToBeHired)
        {
            try
            {
                Customer c = _context.Customers.Find(customerThatsHiring.CustomerID);
                Movie m = _context.Movies.Find(movieToBeHired.MovieId);

                _context.RentedMovies.Add(new RentedMovie() { Customer = c, Movie = m, ReturnDate = new DateTime(2999, 01, 01) });
                //todo: do something more here?
                _context.Database.Log = Console.WriteLine;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public static List<RentedMovie> GetRentedMovies()
        {
            //get all rented movies and include associated 
            //data such as customer renting the movie and 
            //the movie that is being rented
            return _context.RentedMovies
                .Include(c => c.Customer)
                .Include(m => m.Movie)
                .ToList();
        }
    }
}
