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
        /// returns a list of all currently available movies to be hired
        /// </summary>
        /// <returns></returns>
        public static List<Movie> ReturnAvailableMovies()
        {
            List<Movie> availableMovies = ReturnAllMovies();
            List<RentedMovie> hiredMovies = BLLRentedMovie.ReturnAllRentedMovies();
            List<int> movieIDsToBeRemoved = new List<int>();

            for (int i = 0; i < availableMovies.Count; i++)
            {
                for (int j = 0; j < hiredMovies.Count; j++)
                {
                    #region info
                    /*if the current movieid == hired movieid, 
                              then remove the current index from available movies*/ 
                    #endregion
                    if (availableMovies[i].MovieId == hiredMovies[j].Movie.MovieId)
                    {
                        movieIDsToBeRemoved.Add(availableMovies[i].MovieId);
                        break;
                    }
                }
                #region foreach solution
                //SOLVED WITH FOREACH ALSO..
                //foreach (var unavailableMovie in hiredMovies)
                //    {

                //        if (availableMovies[i].MovieId == unavailableMovie.Movie.MovieId)
                //        {
                //            availableMovies.Remove(availableMovies[i]);
                //            break;
                //        }
                //    } 
                #endregion
            }
            #region remove movies that match the int list of stored movie id's to remove
            for (int i = 0; i < availableMovies.Count; i++)
            {
                for (int j = 0; j < movieIDsToBeRemoved.Count; j++)
                {
                    if (availableMovies[i].MovieId == movieIDsToBeRemoved[j])
                    {
                        availableMovies.Remove(availableMovies[i]);
                    }
                }
            } 
            #endregion
            return availableMovies;
        }

        /// <summary>
        /// returns the movie with the corresponding ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Movie ReturnMovieWithID(int id)
        {
            return _context.Movies.Find(id);
        }

        public static bool AddNewRentedMovie(RentedMovie newRentedMovie)
        {
            try
            {
                //addnewrentedmovie method must be here so that we use the same context, and thus save the changes..
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
    }
}
