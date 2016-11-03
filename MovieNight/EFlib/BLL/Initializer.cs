using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFlib.BLL
{
    public class Initializer
    {
        public static void InitializeDatabase()
        {

            DateTime oneWeekFromNow = new DateTime().AddDays(7);

            //initialize database with some default data
            Genre g1 = new Genre() { GenreName = "Action" };
            Genre g2 = new Genre() { GenreName = "ScienceFiction" };
            Genre g3 = new Genre() { GenreName = "Drama" };
            Genre g4 = new Genre() { GenreName = "Romantic" };
            Genre g5 = new Genre() { GenreName = "Thriller" };
            Genre g6 = new Genre() { GenreName = "Horror" };

            Movie m1 = new Movie() { MovieName = "Titanic", MovieDirector = "TitanicDirector", Genre = g4, MovieReleaseDate = new DateTime(1992, 02, 04) };
            Movie m2 = new Movie() { MovieName = "Dont Breathe", MovieDirector = "DontBreatheDirector", Genre = g6, MovieReleaseDate = new DateTime(2016, 02, 04) };
            Movie m3 = new Movie() { MovieName = "Lycky Number Slevin", MovieDirector = "LuckyNumberSlevinDirector", Genre = g1, MovieReleaseDate = new DateTime(2007, 02, 04) };
            Movie m4 = new Movie() { MovieName = "The Mechanic", MovieDirector = "TheMechanicDirector", Genre = g1, MovieReleaseDate = new DateTime(2016, 02, 04) };
            Movie m5 = new Movie() { MovieName = "Gone Girl", MovieDirector = "GoneGirlDirector", Genre = g5, MovieReleaseDate = new DateTime(2014, 02, 04) };

            Customer c1 = new Customer() { CustomerName = "ivan prgomet", CustomerAdress = "langgatan 74", CustomerPhone = "0735709858" };
            Customer c2 = new Customer() { CustomerName = "Jason Bourne", CustomerAdress = "Fifth Avenue", CustomerPhone = "00922039212" };
            Customer c3 = new Customer() { CustomerName = "Cindy Lauper", CustomerAdress = "Dilinger Street 4", CustomerPhone = "00922772212" };


            RentedMovie rm1 = new RentedMovie() { CustomerID = c1.CustomerID, MovieID = m2.MovieId, ReturnDate = oneWeekFromNow };
            RentedMovie rm2 = new RentedMovie() { CustomerID = c2.CustomerID, MovieID = m2.MovieId, ReturnDate = oneWeekFromNow };

            using (MovieRentalContext ctx = new MovieRentalContext())
            {
                ctx.Customers.AddRange(new HashSet<Customer>() { c1, c2, c3 });
                ctx.Movies.AddRange(new HashSet<Movie>() { m1, m2, m3, m4, m5 });
                ctx.Genres.AddRange(new HashSet<Genre>() { g1, g2, g3, g4, g5, g6 });
                ctx.RentedMovies.AddRange(new HashSet<RentedMovie> { rm1, rm2 });

                ctx.Database.Log = Console.WriteLine;
                ctx.SaveChanges();
            };
        }
    }
}
