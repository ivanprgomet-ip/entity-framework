using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Championship:DbContext
    {
        public int ChampionshipId { get; set; }
        public string ChampionshipName { get; set; }

        //these could not be set to internal for some reason. caused nullref. excep. 
        public DbSet<Game>Games { get; set; }
        public DbSet<Player>Players { get; set; }
    }
}
