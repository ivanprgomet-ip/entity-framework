using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new Championship())
            {
                Player player = new Player()
                {
                    PlayerName = "Ivan Prgomet", PlayerEnrollmentDate = DateTime.Now
                };

                ctx.Players.Add(player);
                ctx.SaveChanges(); }
        }

        public void PrintAllPlayers()
        {
            Championship c = new Championship();
            foreach (var player in c.Players)
            {
                Console.WriteLine("Name: "+player.PlayerName+" EnrollmentDate: "+player.PlayerEnrollmentDate);
            }
        }
    }
}
