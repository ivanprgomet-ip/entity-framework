using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud
{
    /// <summary>
    /// contains the presentation layer. gets data from the 
    /// business layer logic class.
    /// </summary>
    class UI
    {
        public void ListAllAuthors()
        {
            using (BooksDB context = new BooksDB())
            {
                List<Author> authors = BLL.ReturnAuthors();
                foreach (var author in authors)
                {
                    Console.WriteLine(author.AuthorID + " " + author.FirstName + " " + author.LastName + " age: " + author.Age);
                }
            }
        }
        public void FindAuthorStartingWith()
        {
            Console.Write("enter starting letters >> ");
            string searchString = Console.ReadLine();

            List<Author> authors = BLL.ReturnAuthors();
            List<Author> matchingAutors = BLL.ReturnMatchingAuthorsSearchString(searchString);

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
        public void SearchForAuthorByID()
        {
            Console.WriteLine("Enter ID: ");
            int searchID = int.Parse(Console.ReadLine());

            Author matchingAuthor = BLL.ReturnMatchingAuthorID(searchID);

            if (matchingAuthor == null)
                Console.WriteLine("No matching author found");
            else
            {
                Console.WriteLine(matchingAuthor.FirstName + " " + matchingAuthor.LastName);
            }

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

            bool authorSuccessfullyAdded = BLL.AddAuthor(author);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(authorSuccessfullyAdded ? "Author successfylly added to database" : "Something went wront");
            Console.ResetColor();
        }
        public void UpdateAuthorName()
        {
            char[] delimiters = new char[] { ' ', ',' };
            string[] tokens;

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

            //returns how many authors match the user input
            int matchingAuthors = BLL.CountMatchingAuthors(firstname, lastname);

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
                using (BooksDB ctx = new BooksDB())
                {
                    Author Update = BLL.GetAuthorToUpdateName(firstname, lastname, ctx);
                    bool updateSucceeded = BLL.UpdateAuthorName(Update, newFirstname, newLastname, ctx);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(updateSucceeded ? "Author successfully updated" : "Update failed");
                    Console.ResetColor();
                }
            }
        }
        public void UpdateAuthorAge()
        {
            Console.Write("Enter ID of author to update age >> ");
            int searchID = int.Parse(Console.ReadLine());

            Author matchingAutor = BLL.ReturnMatchingAuthorID(searchID);
            if (matchingAutor == null)
                Console.WriteLine("No matching author with that ID found");
            else
            {
                Console.Write("Enter new age >> ");
                int newAge = int.Parse(Console.ReadLine());

                //CRUD
                BLL.UpdateAuthorAge(matchingAutor, newAge);
                Console.WriteLine(matchingAutor.FirstName + " " + matchingAutor.LastName + " age updated to " + newAge);
            }
        }
        public void RemoveAuthor()
        {
            Console.WriteLine("Enter ID of author to remove: ");
            int searchID = int.Parse(Console.ReadLine());

            Author matchingAutor = BLL.ReturnMatchingAuthorID(searchID);
            if (matchingAutor == null)
                Console.WriteLine("No matching author with that ID found");
            else
            {
                BLL.RemoveAuthor(searchID);
                Console.WriteLine(matchingAutor.FirstName + " " + matchingAutor.LastName + " removed from database");
            }
        }

        public bool Run()
        {
            Console.WriteLine("[1] List all authors");
            Console.WriteLine("[2] Search for author (firstname/lastname starts with): ");
            Console.WriteLine("[3] Search for an author by ID");
            Console.WriteLine("[4] Add an author");
            Console.WriteLine("[5] Update an existing author name");
            Console.WriteLine("[6] Update an existing author age");
            Console.WriteLine("[7] Remove an author");
            Console.WriteLine("[e] Exit application");
            //string choice = Console.ReadLine();

            ConsoleKeyInfo pressed = Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(pressed.KeyChar);
            Console.ResetColor();

            switch (pressed.Key)
            {
                case ConsoleKey.D1:
                    ListAllAuthors();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case ConsoleKey.D2:
                    FindAuthorStartingWith();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case ConsoleKey.D3:
                    SearchForAuthorByID();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case ConsoleKey.D4:
                    AddAuthor();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case ConsoleKey.D5:
                    UpdateAuthorName();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case ConsoleKey.D6:
                    UpdateAuthorAge();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case ConsoleKey.D7:
                    RemoveAuthor();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case ConsoleKey.E:
                    return false;//only way to exit application
                default:
                    Console.WriteLine("Enter legit command");
                    Console.ReadKey();
                    return true;
            }
            return true;



        }
    }
}