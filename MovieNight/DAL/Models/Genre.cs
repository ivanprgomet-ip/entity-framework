using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNightDataModel
{
    class Genre
    {
        public virtual ICollection<Movie> Movies { get; set; }
        public int GenreID { get; set; }
        public string GenreName { get; set; }


        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }

      

    }
}
