using System.Collections.Generic;

namespace MyMediaApp
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int LengthMinutes{ get; set; }
        public Dictionary<string,string> Top3Actors { get; set; }
        public string Director { get; set;}

        
    }
}