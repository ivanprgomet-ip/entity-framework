using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Game
    {
        public string GameId { get; set; }
        public string GameName { get; set; }
        public IEnumerable<Player> PlayersInGame { get; set; }
    }
}
