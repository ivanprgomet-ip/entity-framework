using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFlib
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }
    }
}
