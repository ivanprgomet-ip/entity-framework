using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            BooksEntities be = new BooksEntities();

            foreach (var author in be.Authors)
            {
                Console.WriteLine("______________");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Authors and Home telephone numbers: " + author.FirstName + " " + author.LastName+" "+author.HomeTel);
                Console.ResetColor();
                Console.WriteLine("______________");
            }

            foreach (var title in be.Titles)
            {
                Console.WriteLine("______________");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("'"+title.Title1 +"' by: ");
                Console.ResetColor();
                foreach (var author in title.Authors)
                {
                    Console.WriteLine(author.FirstName+" "+author.LastName);
                }
                Console.WriteLine("______________");
            }
        }
    }
}
