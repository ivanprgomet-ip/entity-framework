using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFlib.BLL
{
    public class BLLMovie
    {
        static MovieRentalContext _context = new MovieRentalContext();

        public static bool RegisterNewMovie(Movie newMovie)
        {
            try
            {
                _context.Movies.Add(newMovie);
                _context.Database.Log = Console.WriteLine;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<Movie> ReturnAllMovies()
        {
            List<Movie> movies = _context.Movies.ToList();
            return movies;
        }
    }
}
