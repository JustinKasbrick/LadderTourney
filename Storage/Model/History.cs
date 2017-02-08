using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Model
{
    public class History
    {
        public History()
        {
        }

        public History(int id, string tourneyName, int oppenentId, string result)
        {
            Id = id;
            TourneyName = tourneyName;
            OppenentId = oppenentId;
            Result = result;
        }

        public int Id { get; set; }
        public string TourneyName { get; set; }
        public int OppenentId { get; set; }
        public string Result { get; set; }
    }
}
