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

            //foreach (var author in be.Authors)
            //{
            //    Console.WriteLine("______________");
            //    Console.WriteLine("Titles by "+author.FirstName+" "+author.LastName);
            //    foreach (var title in author.Titles)
            //    {
            //        Console.WriteLine(title.Title1+" "+title.EditionNumber+" "+title.ISBN+" "+title.Copyright);
            //    }
            //    Console.WriteLine("______________");
            //}

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
