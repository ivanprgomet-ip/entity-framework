﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNightConsole
{
    public class RentedMovie
    {
        public int RentedID { get; set; }
        public int CustomerID { get; set; }
        public int MovieID { get; set; }
        public DateTime RentedTo { get; set; }
    }
}
