using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobLoot.Models.Loot
{
    public class LootCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character")]
        [MaxLength(30, ErrorMessage = "There are too many characters in this field.")]
        public string LootName { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character")]
        [MaxLength(300, ErrorMessage = "There are too many characters in this field.")]
        public string LootDesc { get; set; }
        [Required]
        public string MonsterName { get; set; }
    }
}
