using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LadderTourney.Ladders;
using Storage.DbContext;
using Storage.Model;

namespace LadderTourney.Events
{
    public class BTA : IEvent
    {
        public string Name { get; }
        public string Division { get; }

        public List<Player> Players { get; }
        public int Buyin { get; }
        public int Prize { get; }
        public bool IsOver { get; set; }
        public Bracket[] Brackets { get; }

        private int _currentBracket = 0;
        private Random _rng = new Random();
            

        public void Step()
        {
            if (_currentBracket >= 8)
                return;

            if (_currentBracket == 7)
            {
                // We done
                Brackets[_currentBracket].PlayerA.Accomplishments.Add(new Accomplishment
                {
                    Name = Name + "Champ"
                });
                Console.WriteLine("Saving Data...");
                using (var context = new TourneyContext())
                {
                    foreach (var player in Players)
                    {
                        var p = context.Players.Find(player.Id);
                        p = player;
                        context.SaveChanges();
                    }
                }
                _currentBracket++;
                IsOver = true;

                return;

            }
            var curBrack = Brackets[_currentBracket];
            if (_rng.Next(0, 100)%2 == 0) // player A wins

            {
                curBrack.PlayerA.Wins++;
                curBrack.PlayerA.Histories.Add(new History(0, curBrack.Name, curBrack.PlayerB.Id, $"{curBrack.PlayerA.Name} def {curBrack.PlayerB.Name}"));
                curBrack.PlayerB.Loses++;
                curBrack.PlayerB.Histories.Add(new History(0, curBrack.Name, curBrack.PlayerA.Id, $"{curBrack.PlayerA.Name} def {curBrack.PlayerB.Name}"));
                curBrack.SetNextBracket(curBrack.PlayerA, Brackets[curBrack.NextBracket], curBrack.Spot);
            }
            else
            {
                curBrack.PlayerB.Wins++;
                curBrack.PlayerB.Histories.Add(new History(0, curBrack.Name, curBrack.PlayerA.Id, $"{curBrack.PlayerB.Name} def {curBrack.PlayerA.Name}"));
                curBrack.PlayerA.Loses++;
                curBrack.PlayerA.Histories.Add(new History(0, curBrack.Name, curBrack.PlayerB.Id, $"{curBrack.PlayerB.Name} def {curBrack.PlayerA.Name}"));
                curBrack.SetNextBracket(curBrack.PlayerB, Brackets[curBrack.NextBracket], curBrack.Spot);
            }


            _currentBracket++;
        }

        public void Draw()
        {
            Console.WriteLine($"{FormatName(Brackets[0].PlayerA.Name, 1)}                                            {FormatName(Brackets[2].PlayerA.Name, 2)}");
            Console.WriteLine($"         {FormatName(Brackets[4].PlayerA?.Name, 1)}                          {FormatName(Brackets[5].PlayerA?.Name, 2)} ");
            Console.WriteLine($"{FormatName(Brackets[0].PlayerB.Name, 1)}                                            {FormatName(Brackets[2].PlayerB.Name, 2)}");
            Console.WriteLine($"                  {FormatName(Brackets[6].PlayerA?.Name, 1)}        {FormatName(Brackets[6].PlayerB?.Name, 2)} ");
            Console.WriteLine($"{FormatName(Brackets[1].PlayerA.Name, 1)}                                            {FormatName(Brackets[3].PlayerA.Name, 2)}");
            Console.WriteLine($"         {FormatName(Brackets[4].PlayerB?.Name, 1)}                          {FormatName(Brackets[5].PlayerB?.Name, 2)} ");
            Console.WriteLine($"{FormatName(Brackets[1].PlayerB.Name, 1)}                                            {FormatName(Brackets[3].PlayerB.Name, 2)}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Winner: {FormatName(Brackets[7].PlayerA?.Name, 2)}");
        }

        public BTA(string name, string division)
        {
            Name = name;
            Division = division;
            Buyin = 200;
            Prize = 1000;
            IsOver = false;

            using (var context = new TourneyContext())
            {
                Players = context.Players.Where(p => p.Division == division).Include(p => p.Histories).Include(p => p.Accomplishments).ToList();
            }
            Players.Shuffle();
            foreach (var player in Players)
            {
                player.Bankroll -= Buyin;
            }

            Brackets = new Bracket[8];


            Brackets[0] = new Bracket($"Div {Division} - {Name} Round 1A", Players[0], Players[1], 4, 0);
            Brackets[1] = new Bracket($"Div {Division} - {Name} Round 1B", Players[2], Players[3], 4, 1);

            Brackets[2] = new Bracket($"Div {Division} - {Name} Round 1C", Players[4], Players[5], 5, 0);
            Brackets[3] = new Bracket($"Div {Division} - {Name} Round 1D", Players[6], Players[7], 5, 1);

            Brackets[4] = new Bracket($"Div {Division} - {Name} Semi-Final A", Brackets[0].Winner, Brackets[1].Winner, 6, 0);
            Brackets[5] = new Bracket($"Div {Division} - {Name} Semi-Final B", Brackets[2].Winner, Brackets[3].Winner, 6, 1);

            Brackets[6] = new Bracket($"Div {Division} - {Name} Final", Brackets[4].Winner, Brackets[5].Winner, 7, 0);

            Brackets[7] = new Bracket($"Div {Division} - {Name} Champion", Brackets[6].Winner, null, 0, 0);

        }

        private string FormatName(string name, int side)
        {
            //side 1 == left
            //side 2 == right
            if (name == null)
                return "________";

            if (side == 2)
            {
                var formattedName = name;
                var numToAdd = 8 - name.Length;
                for (int i = 0; i < numToAdd; i++)
                {
                    formattedName += " ";
                }
                return formattedName;
            }
            else
            {
                var formattedName = "";
                var numToAdd = 8 - name.Length;
                for (int i = 0; i < numToAdd; i++)
                {
                    formattedName += " ";
                }
                return formattedName += name;
            }
        }

        private void SetWinner(Player winner, Player loser)
        {
            
        }
    }
}
