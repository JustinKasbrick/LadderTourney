using Storage.Model;

namespace Storage.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Storage.DbContext.TourneyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Storage.DbContext.TourneyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Players.AddOrUpdate(
                p => p.Name,
                new Player { Bankroll = 1000, Division = "A", Name = "Tricia" },
                new Player { Bankroll = 1000, Division = "A", Name = "Rico" },
                new Player { Bankroll = 1000, Division = "A", Name = "Jenette" },
                new Player { Bankroll = 1000, Division = "A", Name = "Cassidy" },
                new Player { Bankroll = 1000, Division = "A", Name = "Charleen" },
                new Player { Bankroll = 1000, Division = "A", Name = "Bert" },
                new Player { Bankroll = 1000, Division = "A", Name = "Nicholas" },
                new Player { Bankroll = 1000, Division = "A", Name = "Waldo" },

                new Player { Bankroll = 1000, Division = "B", Name = "Madlyn" },
                new Player { Bankroll = 1000, Division = "B", Name = "Rolf" },
                new Player { Bankroll = 1000, Division = "B", Name = "Sophia" },
                new Player { Bankroll = 1000, Division = "B", Name = "Mari" },
                new Player { Bankroll = 1000, Division = "B", Name = "Lavenia" },
                new Player { Bankroll = 1000, Division = "B", Name = "Marvin" },
                new Player { Bankroll = 1000, Division = "B", Name = "Tad" },
                new Player { Bankroll = 1000, Division = "B", Name = "Giuseppe" },

                new Player { Bankroll = 1000, Division = "C", Name = "Katrice" },
                new Player { Bankroll = 1000, Division = "C", Name = "Daniell" },
                new Player { Bankroll = 1000, Division = "C", Name = "Alverta" },
                new Player { Bankroll = 1000, Division = "C", Name = "Hector" },
                new Player { Bankroll = 1000, Division = "C", Name = "Lon" },
                new Player { Bankroll = 1000, Division = "C", Name = "Bradly" },
                new Player { Bankroll = 1000, Division = "C", Name = "Alicia" },

                new Player { Bankroll = 1000, Division = "D", Name = "Sherryl" },
                new Player { Bankroll = 1000, Division = "D", Name = "Greg" },
                new Player { Bankroll = 1000, Division = "D", Name = "Rosetta" },
                new Player { Bankroll = 1000, Division = "D", Name = "Nigel" },
                new Player { Bankroll = 1000, Division = "D", Name = "Daysi" },
                new Player { Bankroll = 1000, Division = "D", Name = "Roman" },
                new Player { Bankroll = 1000, Division = "D", Name = "Karoline" }
                );
            context.SaveChanges();

            context.Events.AddOrUpdate(
                e => e.Name,
                new Event {Division = "A", Name = "BTA 1", EventType = 0, Finished = false},
                new Event {Division = "B", Name = "BTA 1", EventType = 0, Finished = false},
                new Event {Division = "C", Name = "BTA 1", EventType = 0, Finished = false},
                new Event {Division = "D", Name = "BTA 1", EventType = 0, Finished = false},

                new Event {Division = "A", Name = "BTA 2", EventType = 0, Finished = false},
                new Event {Division = "B", Name = "BTA 2", EventType = 0, Finished = false},
                new Event {Division = "C", Name = "BTA 2", EventType = 0, Finished = false},
                new Event {Division = "D", Name = "BTA 2", EventType = 0, Finished = false},

                new Event {Division = "A", Name = "BTA 3", EventType = 0, Finished = false},
                new Event {Division = "B", Name = "BTA 3", EventType = 0, Finished = false},
                new Event {Division = "C", Name = "BTA 3", EventType = 0, Finished = false},
                new Event {Division = "D", Name = "BTA 3", EventType = 0, Finished = false}
                );
            context.SaveChanges();
        }
    }
}
