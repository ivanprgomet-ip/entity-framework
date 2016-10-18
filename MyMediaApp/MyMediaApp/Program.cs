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
            mc.Papers.Add(new Paper() { Type = PaperType.Essay, Author = "Ralph Waldo Emerson", Name = "Fate" });
            //mc.SaveChanges();


            //CRUD
            //InsertBook("authordemo", "action", "title", 999);
            //InsertMovie("ivano prgometo", "action", "some cool title", 120);
            //InsertPaper("ivan emeroson", "life", PaperType.Essay);

            //RemoveBooks("title");
            //RemoveMovies("some cool title");
            //RemovePaper("life");

            QueryBooks(mc);
            QueryMovies(mc);
            QueryPapers(mc);



        }

        private static void RemovePaper(string papername)
        {
            //will only remove first instance of paper found that matches the parameter name
            MediaContext context = new MediaContext();
            Paper paperToRemove = context.Papers.Where(p => p.Name == papername).FirstOrDefault();
            if (paperToRemove == null)
                Console.WriteLine("Paper " + papername + " not present in database");
            else
            {
                context.Papers.Remove(paperToRemove);
                context.SaveChanges();
            }
        }
        private static void RemoveMovies(string moviename)
        {
            //will remove all movies that matche the parameter name
            MediaContext context = new MediaContext();
            IEnumerable<Movie> moviesToRemove = context.Movies.Where(m => m.Name == moviename);

            if (moviesToRemove.Count() == 0)
                Console.WriteLine("Movie " + moviename + " not present in database");
            else
            {
                context.Movies.RemoveRange(moviesToRemove);
                context.SaveChanges();
            }
        }
        private static void RemoveBooks(string bookname)
        {
            //will remove all books that matche the parameter name
            MediaContext context = new MediaContext();
            IEnumerable<Book> booksToRemove = context.Books.Where(b => b.Name == bookname);

            if (booksToRemove.Count() == 0)
                Console.WriteLine("Book " + bookname + " not present in database");
            else
            {
                Console.WriteLine("Book(s) with name " + bookname + " successfully removed");
                context.Books.RemoveRange(booksToRemove);
                context.SaveChanges();
            }
        }

        public static void QueryBooks(MediaContext context)
        {
            Console.WriteLine("_____________Books_____________");

            foreach (var book in context.Books)
            {
                Console.WriteLine($"'{book.Name}' - {book.Author} ({book.Genre}, {book.Pages})");
            }
            Console.WriteLine("___________________");
        }
        public static void QueryMovies(MediaContext context)
        {
            Console.WriteLine("_____________Movies_____________");
            foreach (var movie in context.Movies)
            {
                Console.WriteLine($"'{movie.Name}' - {movie.Director} ({movie.LengthMinutes})");
                //foreach (KeyValuePair<string,string> kvp in movie.Top3Actors)
                //{
                //    Console.WriteLine(kvp.Key+" "+kvp.Value);
                //}
            }
            Console.WriteLine("___________________");

        }
        public static void QueryPapers(MediaContext context)
        {
            Console.WriteLine("_____________Papers_____________");
            foreach (var paper in context.Papers)
            {
                Console.WriteLine($"'{paper.Name}' - {paper.Author} ({paper.Type})");
            }
            Console.WriteLine("___________________");

        }

        public static void InsertBook(string author, string genre, string name, int pages)
        {
            var book = new Book()
            {
                Author = author,
                Genre = genre,
                Name = name,
                Pages = pages,
            };

            MediaContext context = new MediaContext();
            context.Books.Add(book);
            context.SaveChanges();
        }
        public static void InsertMovie(string director, string genre, string name, int lengthMinutes)
        {
            var movie = new Movie()
            {
                Director = director,
                Genre = genre,
                Name = name,
                LengthMinutes = lengthMinutes,
                //top3actors dictionary not supported by EF
            };

            MediaContext context = new MediaContext();
            context.Movies.Add(movie);
            context.SaveChanges();
        }
        public static void InsertPaper(string author, string name, PaperType type)
        {
            var paper = new Paper()
            {
                Author = author,
                Type = type,
                Name = name,
            };

            MediaContext context = new MediaContext();
            context.Papers.Add(paper);
            context.SaveChanges();
        }
    }
}
