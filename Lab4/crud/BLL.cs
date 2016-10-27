using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud
{
    /// <summary>
    /// this class comunicates with the context class which is responsible for 
    /// interacting with data as objects / comunication with the database. 
    /// which makes this class the business layer logic.
    /// </summary>
    static class BLL
    {
        static BooksDB _context;

        internal static List<Author> ReturnAuthors()
        {
            using (BooksDB ctx = new BooksDB())
            {
                List<Author> authors = new List<Author>();
                foreach(var author in ctx.Authors)
                {
                    authors.Add(author);
                }
                return authors;
            }
        }

        internal static List<Author> ReturnMatchingAuthorsSearchString(string searchString)
        {
            return ReturnAuthors().Where(a => a.FirstName.StartsWith(searchString) || a.LastName.StartsWith(searchString)).ToList();
        }

        internal static Author ReturnMatchingAuthorID(int searchID)
        {
            return ReturnAuthors().Where(a => a.AuthorID == searchID).FirstOrDefault();
        }

        internal static bool AddAuthor(Author author)
        {
            using (_context = new BooksDB())
            {
                try
                {
                    _context.Authors.Add(author);
                    _context.Database.Log = Console.WriteLine;
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
