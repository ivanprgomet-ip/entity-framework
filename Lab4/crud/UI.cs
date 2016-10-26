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
                    Console.WriteLine(author.AuthorID+" "+ author.FirstName + " " + author.LastName+" age: "+author.Age);
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
        public void UpdateAuthorName()
        {
            char[] delimiters = new char[] { ' ', ',' };
            string[] tokens;

            //make sure the user inputs a fullname of firstname and lastname
            #region make sure user inputs fullname in one line
            while (true)
            {
                Console.Write("Enter author fullname >> ");
                string fullname = Console.ReadLine();

                tokens = fullname.Split(delimiters);//array will contain the firstname and lastname split by space or ,

                if (tokens.Length > 1)
                    break;
                else
                    Console.WriteLine("Fullname not entered...");
            }
            #endregion

            string firstname = tokens[0];
            string lastname = tokens[1];

            #region CRUD
            using (BooksDB ctx = new BooksDB())
            {
                //returns how many authors match the user input
                int matchingAuthors = ctx.Authors.Where(a => a.FirstName.Equals(firstname) && a.LastName.Equals(lastname)).Count();

                if (matchingAuthors > 1)
                    Console.WriteLine(matchingAuthors + " matching authors found");
                else if (matchingAuthors == 1)
                {
                    Console.WriteLine(matchingAuthors + " matching author found");
                    Console.Write("Enter new firstname >> ");
                    string newFirstname = Console.ReadLine();
                    Console.Write("Enter new lastname >> ");
                    string newLastname = Console.ReadLine();

                    //CRUD OPERATION FOR UPDATING 
                    Author UpdateMe = (from a in ctx.Authors
                                       where a.FirstName.Equals(firstname)
                                       && a.LastName.Equals(lastname)
                                       select a).First();
                    UpdateMe.FirstName = newFirstname;
                    UpdateMe.LastName = newLastname;
                    ctx.Database.Log = Console.WriteLine;
                    ctx.SaveChanges();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Author successfully updated");
                    Console.ResetColor();
                }
            } 
            #endregion
        }
        public void UpdateAuthorAge()
        {
            Console.Write("Enter ID of author to update age >> ");
            int searchID = int.Parse(Console.ReadLine());

            using (BooksDB context = new BooksDB())
            {
                Author matchingAutor = context.Authors.Where(a => a.AuthorID == searchID).FirstOrDefault();
                if (matchingAutor == null)
                    Console.WriteLine("No matching author with that ID found");
                else
                {
                    Console.Write("Enter new age >> ");
                    int newAge = int.Parse(Console.ReadLine());

                    //CRUD
                    Author ToBeUpdated = context.Authors.Where(a => a.AuthorID.Equals(searchID)).First();
                    ToBeUpdated.Age = newAge;
                    context.Database.Log = Console.WriteLine;
                    context.SaveChanges();

                    Console.WriteLine(matchingAutor.FirstName + " " + matchingAutor.LastName + " age updated to "+newAge);
                }
            }
            Console.ReadKey();
        }
        public void RemoveAuthor()
        {
            Console.WriteLine("Enter ID of author to remove: ");
            int searchID = int.Parse(Console.ReadLine());
            using (BooksDB context = new BooksDB())
            {
                Author matchingAutor = context.Authors.Where(a => a.AuthorID == searchID).FirstOrDefault();
                if (matchingAutor == null)
                    Console.WriteLine("No matching author with that ID found");
                else
                {
                    //CRUD
                    context.Authors.Remove(context.Authors.Where(a => a.AuthorID.Equals(searchID)).First());//remove author with mathcing ID
                    context.Database.Log = Console.WriteLine;
                    context.SaveChanges();

                    Console.WriteLine(matchingAutor.FirstName + " " + matchingAutor.LastName +" removed from database");
                }
            }
            Console.ReadKey();
        }
    }
}