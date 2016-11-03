using System;
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
            //Database.SetInitializer<new System.Data.Entity.DropCreateDatabaseIfModelChanges>()>

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<RentedMovie> RentedMovies { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
