using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMediaApp
{
    class MediaContext:DbContext
    {
        public DbSet<Paper> Papers { get; set; }
        public DbSet<Movie> Movies{ get; set; }
        public DbSet<Book> Books{ get; set; }
    }
}
