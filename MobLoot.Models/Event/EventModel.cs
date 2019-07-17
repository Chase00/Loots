using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobLoot.Models.Event
{
    public class EventModel
    {
        public int MonsterId { get; set; }
        public int LootId { get; set; } 
        public string LootName { get; set; }
    }
}
