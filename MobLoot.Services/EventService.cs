using MobLoot.Data;
using MobLoot.Models;
using MobLoot.Models.Event;
using MobLoot.Models.Loot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobLoot.Services
{
    public class EventService
    {
        private readonly Guid _userId;

        public EventService(Guid userId)
        {
            _userId = userId;
        }

        public EventModel RandomLoot(EventModel model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var lootList = ctx.Loot.Where(e => e.OwnerId == _userId && e.MonsterId == model.MonsterId).ToList();
                var random = new Random(); // random
                var lengthList = lootList.Count;
                var genNum = random.Next(0, lengthList);
                int getList = lootList[genNum].LootId;

                //var index = random.Next(lootList.Count); //Counting items in the LootList and giving a random number from the list

                return new EventModel()
                {
                    MonsterId = model.MonsterId,
                    LootId = getList,
                    LootName = lootList[genNum].LootName

                    
                };
            }
        }
    }
    // returning the loot item from that random pick as a string 
}