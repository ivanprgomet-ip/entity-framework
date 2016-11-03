using System;
using System.Collections.Generic;

namespace MovieNightConsole
{
    internal class Movie
    {
        //public int MovieID { get; set; }
        //public string MovieTitle { get; set; }
        //public string MovieGenre { get; set; }
        //public int MovieLength{ get; set; }
        //public Dictionary<string,string> MovieTop3Actors { get; set; }
        //public string MovieDirector { get; set;}


        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieDirector { get; set; }
        public DateTime? MovieReleaseDate { get; set; }
        public int? GenreID { get; set; }
        public virtual Genre Genre { get; set; }
    }
}