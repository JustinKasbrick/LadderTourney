using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Model
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Division { get; set; }
        public int EventType { get; set; }
        public bool Finished { get; set; }
        public string Champ { get; set; }
        public string RunnerUp { get; set; }
    }
}
