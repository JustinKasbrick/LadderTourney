using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LadderTourney.Screens;

namespace LadderTourney
{
    public class Program
    {
        private static IScreen _currentScreen = new MainScreen();
        private static bool _running = true;

        static void Main(string[] args)
        {
            while (_running)
            {
                _currentScreen.Draw();
                _currentScreen.GetInput();
                _currentScreen = _currentScreen.Update();

                if (_currentScreen == null)
                    _running = false;
            }

            Console.Clear();
            Console.WriteLine("Good Bye!");
            System.Threading.Thread.Sleep(100);
        }
    }
}
