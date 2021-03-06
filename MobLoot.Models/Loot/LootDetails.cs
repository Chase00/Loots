﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobLoot.Models.Loot
{
    public class LootDetails
    {
        public int LootId { get; set; }
        [Display(Name = "Loot Name: ")]
        public string LootName { get; set; }
        [Display(Name = "Loot Description: ")]
        public string LootDesc { get; set; }
        [Display(Name = "Monster: ")]
        public string MonsterName { get; set; }
        public int MonsterId { get; set; }
    }
}
