﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobLoot.Models.Loot
{
    public class LootEdit
    {
        public int LootId { get; set; }
        [MinLength(1, ErrorMessage = "Please enter at least 1 character")]
        [MaxLength(30, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Loot: ")]
        public string LootName { get; set; }
        [MinLength(1, ErrorMessage = "Please enter at least 1 character")]
        [MaxLength(300, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Description: ")]
        public string LootDesc { get; set; }
        [Display(Name = "Monster: ")]
        public int MonsterId { get; set; }
    }
}
