using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud
{
    class UI
    {
        public void ListAllAuthors()
        {
            using (BooksDB context = new BooksDB())
            {
                foreach (var author in context.Authors)//why is Authors null? because you were using the wrong context class
                {
                    Console.WriteLine(author.FirstName + " " + author.LastName);
                }
            }
            Console.ReadKey();
        }
        public void FindAuthorStartingWith()
        {
            Console.WriteLine("Search for author: ");
            string searchString = Console.ReadLine();
            using (BooksDB context = new BooksDB())
            {
                List<Author> matchingAutors = context.Authors.Where(a => a.FirstName.StartsWith(searchString) || a.LastName.StartsWith(searchString)).ToList();
                if (matchingAutors.Count == 0)
                    Console.WriteLine("No matching authors were found");
                else
                {
                    foreach (var author in matchingAutors)
                    {
                        Console.WriteLine(author.FirstName + " " + author.LastName);
                    }
                }
            }
            Console.ReadKey();
        }
        public void SearchForAuthorByID()
        {
            Console.WriteLine("Enter ID: ");
            int searchID = int.Parse(Console.ReadLine());
            using (BooksDB context = new BooksDB())
            {
                Author matchingAutor = context.Authors.Where(a => a.AuthorID == searchID).FirstOrDefault();
                if (matchingAutor == null)
                    Console.WriteLine("No matching author found");
                else
                {
                    Console.WriteLine(matchingAutor.FirstName + " " + matchingAutor.LastName);
                }
            }
            Console.ReadKey();
        }
        public void AddAuthor()
        {
            Console.WriteLine("Enter author firstname: ");
            string firstname = Console.ReadLine();
            Console.WriteLine("Enter author lastname: ");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter author phone number: ");
            string phone = Console.ReadLine();

            Author author = new Author()
            {
                FirstName = firstname,
                LastName = lastname,
                HomeTel = phone,
                PaymentMethod = 0,
            };
            using (BooksDB context = new BooksDB())
            {
                context.Authors.Add(author);
                context.Database.Log = Console.WriteLine;
                context.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Author successfylly added to database");
                Console.ResetColor();
            }
        }
    }
}