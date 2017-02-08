using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadderTourney
{
    public interface IScreen
    {
        void Draw();
        void GetInput();
        IScreen Update();
    }
}
