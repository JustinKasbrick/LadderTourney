using System;
using System.Collections.Generic;
using System.Linq;
using Storage.DbContext;
using Storage.Model;

namespace LadderTourney.Screens
{
    public class PlayerScreen : IScreen
    {
        private ConsoleKeyInfo Selection { get; set; }
        private List<Player> Players { get; set; }

        public PlayerScreen()
        {
            Console.Clear();
            Console.WriteLine("Loading ...");
            using (var context = new TourneyContext())
            {
                Players = context.Players.ToList();
            }
        }

        public void Draw()
        {

            Console.Clear();
            Console.WriteLine("Name     Wins    Loses   Bankroll");
            foreach (var player in Players)
            {
                Console.WriteLine($"{player.Name}   {player.Wins}   {player.Loses}  {player.Bankroll}   {player.Division}");
            }

            Console.WriteLine();
            Console.WriteLine("Q) Quit");
            Console.WriteLine();
            Console.WriteLine("Selection: ");
        }

        public void GetInput()
        {
            Selection = Console.ReadKey();
        }

        public IScreen Update()
        {
            switch (Selection.Key)
            {
                case ConsoleKey.Q:
                    return new MainScreen();
                default:
                    return this;
            }
        }
    }
}
