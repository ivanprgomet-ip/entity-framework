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
                Console.WriteLine("[2] Visa namn som börjar på...");
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
                    default:
                        Console.WriteLine("Please enter legit input");
                        break;
                }

            }
        }
    }
}
