using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud
{
    class DataAccess
    {
        public List<Author> FindAuthor(string letter)
        {
            List<Author> authors = new List<Author>();
            using (BooksDB context = new BooksDB())
            {
                foreach (var author in context.Authors)
                {
                    if(author.FirstName.StartsWith(letter) || author.LastName.StartsWith(letter))
                        authors.Add(author);
                }
            }
            return authors;
        }
    }
}
