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

        public static bool AddNewRentedMovie(RentedMovie newRentedMovie)
        {
            try
            {
                //todo: when making a new hire, the catch is run, this is never saved..
                _context.RentedMovies.Add(newRentedMovie);
                _context.Database.Log = Console.WriteLine;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<RentedMovie> ReturnAllRentedMovies()
        {
            List<RentedMovie> rentedMovies = _context.RentedMovies
                .Include(c => c.Movie)
                .Include(c => c.Customer)
                .ToList();
            return rentedMovies;
        }
    }
}
