using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LadderTourney.Events;
using Storage.DbContext;

namespace LadderTourney.Screens
{
    public class EventScreen : IScreen
    {
        private ConsoleKeyInfo Selection { get; set; }
        private IEvent Event { get; set; }

        public EventScreen()
        {
            Console.Clear();
            Console.WriteLine("Loading ...");
            using (var context = new TourneyContext())
            {
                var nextEvent = context.Events.FirstOrDefault(e => e.Finished == false);
                if (nextEvent == null)
                    return;

                switch (nextEvent.EventType)
                {
                    case 0:
                        Event = new BTA(nextEvent.Name, nextEvent.Division);
                        break;
                }
            }
        }

        public void Draw()
        {
            Console.Clear();
            Console.WriteLine($"Dvision {Event.Division} - {Event.Name}");
            Console.WriteLine();
            Event.Draw();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press Space to continue");
        }

        public void GetInput()
        {
            Selection = Console.ReadKey();
        }

        public IScreen Update()
        {
            if(Event.IsOver)
                return new MainScreen();

            switch (Selection.Key)
            {
                case ConsoleKey.Spacebar:
                    Event.Step();
                    return this;
            }

            return this;
        }
    }
}
