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
        DbSet<Paper> Papers { get; set; }
        DbSet<Movie> Movies{ get; set; }
        DbSet<Book> Books{ get; set; }
    }
}
