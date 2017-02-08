using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Model
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Division { get; set; }
        public int Bankroll { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }

        public virtual ICollection<History> Histories { get; set; } = new List<History>();
        public virtual ICollection<Accomplishment> Accomplishments { get; set; } = new List<Accomplishment>();
    }
}
