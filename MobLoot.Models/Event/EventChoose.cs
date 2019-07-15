using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobLoot.Models.Event
{
    public class EventChoose
    {
        [Required]
        [Display(Name = "Monster: ")]
        public int MonsterId { get; set; }
    }
}
