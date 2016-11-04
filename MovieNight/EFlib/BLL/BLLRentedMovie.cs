﻿using System;
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
                    currentCustomersMovies.Add(rentedMovie.Movie);//TODO: WHY IS THIS NULL?
                    rentalsDict.Add(rentedMovie.Customer, currentCustomersMovies);
                }
            }
            return rentalsDict;
        }

        public static bool RemoveMovieWithID(int returnMovieID)
        {
            try
            {
                //removes the movie with specific id and saves the changes
                _context.RentedMovies.Remove(_context.RentedMovies.Find(returnMovieID));
                _context.Database.Log = Console.WriteLine;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
