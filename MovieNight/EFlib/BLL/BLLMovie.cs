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

        /// <summary>
        /// return movies that are not rented, and thus currently available
        /// </summary>
        /// <returns></returns>
        public static List<Movie> ReturnAvailableMovies()
        {
            List<Movie> notHiredMovies = ReturnAllMovies();
            List<RentedMovie> hiredMovies = BLLRentedMovie.ReturnAllRentedMovies();

            for (int i = 0; i < notHiredMovies.Count; i++)
            {
                for (int j = 0; j < hiredMovies.Count; j++)
                {
                    if (notHiredMovies[i].MovieId == hiredMovies[j].Movie.MovieId)
                    {
                        notHiredMovies.Remove(notHiredMovies[i]);
                        break;
                    }
                }

                //SOLVED WITH FOREACH ALSO..
                //foreach (var unavailableMovie in hiredMovies)
                //{
                //    if (notHiredMovies[i].MovieId == unavailableMovie.Movie.MovieId)
                //    {
                //        notHiredMovies.Remove(notHiredMovies[i]);
                //        break;
                //    }
                //}
            }
            return notHiredMovies;
        }
    }
}
