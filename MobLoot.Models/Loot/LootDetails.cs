using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobLoot.Models.Loot
{
    public class LootDetails
    {
        public int LootId { get; set; }
        public string LootName { get; set; }
        public string LootDesc { get; set; }
        public string MonsterName { get; set; }
        public int MonsterId { get; set; }
    }
}
