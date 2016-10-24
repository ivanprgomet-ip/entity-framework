using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    /// <summary>
    /// 3.3	Linq
    /// 3.4 Linq and Lambda combined against simple type list
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>()
            {
                "amanda","ben","cindy","doug","emil","fredrik","gustav","greta"
            };

            while (true)
            {
                Console.WriteLine("[1] visa alla namn");
                Console.WriteLine("[2] Visa namn som börjar på... (linq)");
                Console.WriteLine("[3] visa alla namn som inte innehåller bokstaven... (lambda)");
                Console.WriteLine("[4] visa alla namn som börjar på bokstaven och inte innehåller bokstaven... (lambda)");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        foreach (var name in names)
                        {
                            Console.WriteLine(name);
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("Bokstav >> ");
                        string letter = Console.ReadLine();
                        IEnumerable namesStartingWith = names.Where(n => n.StartsWith(letter));
                        foreach (var name in namesStartingWith)
                        {
                            Console.WriteLine(name);
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        //extract names that dont contain the letter...
                        Console.WriteLine("Bokstav >> ");
                        string letter2 = Console.ReadLine();
                        IEnumerable namesWithoutS = names.Where(n => !n.Contains(letter2));
                        foreach (var name in namesWithoutS)
                        {
                            Console.WriteLine(name);
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        Console.WriteLine("Som börjar på  bokstaven >> ");
                        string startingLetter = Console.ReadLine();
                        Console.WriteLine("Som inte innehåller bokstaven >> ");
                        string doesntContainLetter = Console.ReadLine();

                        IEnumerable namesCollection = names.Where(n => n.StartsWith(startingLetter) && !n.Contains(doesntContainLetter));
                         foreach (var name in namesCollection)
                        {
                            Console.WriteLine(name);
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Please enter legit input");
                        break;
                }
            }
        }
    }
}
