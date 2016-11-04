using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFlib
{
    public class RentedMovie
    {
        [Key]
        public int RentedID { get; set; }

        //public int CustomerID { get; set; }
        //public int MovieID { get; set; }
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }

        public DateTime ReturnDate { get; set; }

        public RentedMovie()
        {
            Customer = new Customer();
            Movie = new Movie();
            //add new datetime with one week ahead
        }
    }
}
