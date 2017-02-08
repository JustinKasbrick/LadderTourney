using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Model;

namespace LadderTourney.Ladders
{
    public class Bracket
    {
        public Bracket(string name, Player playerA, Player playerB, int nextBracket, int spot)
        {
            Name = name;
            PlayerA = playerA;
            PlayerB = playerB;
            NextBracket = nextBracket;
            Spot = spot;
        }

        public string Name { get; set; }
        public Player PlayerA { get; set; }
        public Player PlayerB { get; set; }
        public Player Winner { get; set; }
        public Player Loser { get; set; }
        public int NextBracket { get; set; }
        public int Spot { get; set; }

        public void SetNextBracket(Player winner, Bracket bracket, int n)
        {
            if (n == 0)
            {
                bracket.PlayerA = winner;
            }
            else
            {
                bracket.PlayerB = winner;
            }
        }
    }

}
