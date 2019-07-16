using MobLoot.Data;
using MobLoot.Models;
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
        //public IEnumerable<LootListItem> GetLoot()
        //{
        //    // Calls the database
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        // sets the database to 'query'
        //        var query = ctx
        //            .Loot
        //            .Where(entity => entity.OwnerId == _userId) // .Where filters to check to verify the logged in user is the creator
        //            .Select(
        //                entity => // Commands the entity to go to a new instance of LootListItem
        //                    new LootListItem
        //                    {
        //                        // Sets the class to take in the model information (What the user inputs)
        //                        LootId = entity.LootId,
        //                        LootName = entity.LootName,
        //                        LootDesc = entity.LootDesc,
        //                        MonsterName = entity.Monsters.MonsterName

        //                    }
        //            );
        //        // Returns the Information
        //        return query.OrderBy(prod => prod.MonsterName).ToArray();
        //    }
        //}
    }
}
