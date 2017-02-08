using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Storage.Model;

namespace LadderTourney.Events
{
    public interface IEvent
    {
        string Name { get; }
        string Division { get; }
        List<Player> Players { get; }
        int Buyin { get; }
        int Prize { get; }
        bool IsOver { get; }

        void Step();
        void Draw();
    }
}
