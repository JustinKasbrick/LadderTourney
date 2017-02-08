using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadderTourney.Screens
{
    public class MainScreen : IScreen
    {
        private ConsoleKeyInfo Selection { get; set; }

        public void Draw()
        {
            Console.Clear();
            Console.WriteLine("A) Players");
            Console.WriteLine("B) Play Next Event");
            Console.WriteLine("Q) Quit");

            Console.WriteLine();
            Console.Write("Selection: ");
        }

        public void GetInput()
        {
            Selection = Console.ReadKey();
        }

        public IScreen Update()
        {
            switch (Selection.Key)
            {
                case ConsoleKey.A:
                    return new PlayerScreen();
                case ConsoleKey.B:
                    return new EventScreen();
                case ConsoleKey.Q:
                    return null;
                default:
                    return this;
            }
        }
    }
}
