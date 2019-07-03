using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobLoot.Models
{
    public class MonstersListItem
    {
        [Display(Name = "Monster: ")]
        public string MonsterName { get; set; }
        [Display(Name = "Level: ")]
        public short MonsterLevel { get; set; }
        [Display(Name = "Description")]
        public string MonsterDesc { get; set; }
    }
}

