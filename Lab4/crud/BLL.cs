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
        static BooksDB _context = new BooksDB();

        internal static List<Author> ReturnAuthors()
        {
            using (BooksDB ctx = new BooksDB())
            {
                List<Author> authors = new List<Author>();
                foreach (var author in ctx.Authors)
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

        internal static int CountMatchingAuthors(params string[] names)
        {
            return ReturnAuthors().Where(a => a.FirstName.Equals(names[0]) && a.LastName.Equals(names[1])).Count();
        }

        internal static Author GetAuthorToUpdateName(string firstname, string lastname,BooksDB ctx)
        {
            //returns the author which is to be updated
            return (from a in ctx.Authors
                    where a.FirstName.Equals(firstname)
                    && a.LastName.Equals(lastname)
                    select a).First();
        }
        internal static bool UpdateAuthorName(Author update, string newfirstname, string newlastname, BooksDB ctx)
        {
            try
            {
                update.FirstName = newfirstname;
                update.LastName = newlastname;
                ctx.Database.Log = Console.WriteLine;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
