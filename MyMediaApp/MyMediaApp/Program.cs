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

            mc.SaveChanges();
            Console.WriteLine("Changes saved");
        }
    }
}
