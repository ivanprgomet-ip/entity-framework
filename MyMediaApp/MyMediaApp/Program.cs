using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMediaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MediaContext mc = new MediaContext();

            mc.Books.Add(new Book() { Name = "I am Ivan", Author = "ivan prgomet", Genre = "Drama", Pages = 560 });
            mc.Movies.Add(new Movie()
            {
                Name = "Don't Breathe",
                Top3Actors = new Dictionary<string, string>
                {
                    { "Stephen Lang", "The Blind Man" },
                    { "Jane Levy", "Rocky"},
                    { "Dylan Minnette", "Alex" },
                }
            });
            mc.Papers.Add(new Paper() { type = PaperType.Essay, Author = "Ralph Waldo Emerson", Name = "Fate" });
            //mc.SaveChanges();


            QueryBooks(mc);
            QueryMovies(mc);
            QueryPapers(mc);


        }
        public static void QueryBooks(MediaContext context)
        {
            foreach (var book in context.Books)
            {
                Console.WriteLine($"'{book.Name}' - {book.Author} ({book.Genre}, {book.Pages})");
            }
        }
        public static void QueryMovies(MediaContext context)
        {
            foreach (var movie in context.Movies)
            {
                Console.WriteLine($"'{movie.Name}' - {movie.Director} ({movie.LengthMinutes})");
                //foreach (KeyValuePair<string,string> kvp in movie.Top3Actors)
                //{
                //    Console.WriteLine(kvp.Key+" "+kvp.Value);
                //}
            }
        }
        public static void QueryPapers(MediaContext context)
        {
            foreach (var paper in context.Papers)
            {
                Console.WriteLine($"'{paper.Name}' - {paper.Author} ({paper.type})");
            }
        }


    }
}
