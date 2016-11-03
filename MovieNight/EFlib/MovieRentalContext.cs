﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFlib
{
    public class MovieRentalContext : DbContext
    {

        public MovieRentalContext() : base("name=MovieRentalConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways());
            //Seed(this);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<RentedMovie> RentedMovies { get; set; }
        public DbSet<Genre> Genres { get; set; }


        #region dropcreatedatabase always
        public class DropCreateDatabaseAlways : DropCreateDatabaseAlways<MovieRentalContext>
        {
            protected override void Seed(MovieRentalContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }
        private void Seed(MovieRentalContext ctx)
        {
            DateTime oneWeekFromNow = new DateTime().AddDays(7);

            //initialize database with some default data
            Genre g1 = new Genre() { GenreName = "Action" };
            Genre g2 = new Genre() { GenreName = "ScienceFiction" };
            Genre g3 = new Genre() { GenreName = "Drama" };
            Genre g4 = new Genre() { GenreName = "Romantic" };
            Genre g5 = new Genre() { GenreName = "Thriller" };
            Genre g6 = new Genre() { GenreName = "Horror" };
            Genre g7 = new Genre() { GenreName = "Mystic" };


            Movie m1 = new Movie() { Genre = g4, MovieName = "Titanic", MovieDirector = "TitanicDirector", MovieReleaseDate = new DateTime(1992, 02, 04) };
            Movie m2 = new Movie() { Genre = g6, MovieName = "Dont Breathe", MovieDirector = "DontBreatheDirector", MovieReleaseDate = new DateTime(2016, 02, 04) };
            Movie m3 = new Movie() { Genre = g1, MovieName = "Lycky Number Slevin", MovieDirector = "LuckyNumberSlevinDirector", MovieReleaseDate = new DateTime(2007, 02, 04) };
            Movie m4 = new Movie() { Genre = g1, MovieName = "The Mechanic", MovieDirector = "TheMechanicDirector", MovieReleaseDate = new DateTime(2016, 02, 04) };
            Movie m5 = new Movie() { Genre = g5, MovieName = "Gone Girl", MovieDirector = "GoneGirlDirector", MovieReleaseDate = new DateTime(2014, 02, 04) };

            Customer c1 = new Customer() { CustomerName = "Ivan Prgomet", CustomerAdress = "langgatan 74", CustomerPhone = "0735709858" };
            Customer c2 = new Customer() { CustomerName = "Jason Bourne", CustomerAdress = "Fifth Avenue", CustomerPhone = "00922039212" };
            Customer c3 = new Customer() { CustomerName = "Cindy Lauper", CustomerAdress = "Dilinger Street 4", CustomerPhone = "00922772212" };

            RentedMovie rm1 = new RentedMovie() { Customer = c1, Movie = m2, ReturnDate = new DateTime(2020, 03, 12) };
            RentedMovie rm2 = new RentedMovie() { Customer = c2, Movie = m2, ReturnDate = new DateTime(2020, 03, 12) };

            ctx.Customers.AddRange(new HashSet<Customer>() { c1, c2, c3 });
            ctx.Genres.AddRange(new HashSet<Genre>() { g1, g2, g3, g4, g5, g6, g7 });
            ctx.Movies.AddRange(new HashSet<Movie>() { m1, m2, m3, m4, m5 });
            ctx.RentedMovies.AddRange(new HashSet<RentedMovie> { rm1, rm2 });

            //ctx.Database.Log = Console.WriteLine;
            ctx.SaveChanges();
        }
        #endregion
    }
}
