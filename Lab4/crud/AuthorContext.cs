﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud
{
    class AuthorContext:DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Title> Titles{ get; set; }


        
    }
}
