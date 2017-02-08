using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Model;

namespace Storage.DbContext
{
    public class TourneyContext : System.Data.Entity.DbContext
    {
        public TourneyContext() : base ("TourneyContext")
        {
        }

        public DbSet<Accomplishment> Accomplishments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
