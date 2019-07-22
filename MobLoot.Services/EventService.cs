using MobLoot.Data;
using MobLoot.Models;
using MobLoot.Models.Event;
using MobLoot.Models.History;
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

                return new EventModel()
                {
                    MonsterId = model.MonsterId,
                    MonsterName = model.MonsterName,
                    LootId = getList,
                    LootName = lootList[genNum].LootName      
                };
            }
        }

        //public HistoryListItem HistoryCap()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var lootList = ctx.Loot.Where(e => e.OwnerId == _userId && e.MonsterId == model.MonsterId).ToList();
        //        var random = new Random(); // random
        //        var lengthList = lootList.Count;
        //        var genNum = random.Next(0, lengthList);
        //        int getList = lootList[genNum].LootId;

        //        if (lengthList >= 10)
        //        {

        //        }

        //        return new EventModel()
        //        {
        //            MonsterId = model.MonsterId,
        //            MonsterName = model.MonsterName,
        //            LootId = getList,
        //            LootName = lootList[genNum].LootName
        //        };
        //    }
        //}


        public bool DeleteOldestEntry()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .History
                        .Single(e => e.OwnerId == _userId);
                ctx.History.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<HistoryListItem> GetHistory() // Allows us to see the specific monsters that belong to a specific user
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .History
                    .Where(entity => entity.OwnerId == _userId)
                    .Select(
                        entity =>
                            new HistoryListItem
                            {
                                HistoryId = entity.HistoryId,
                                OwnerId = entity.OwnerId,
                                MonsterName = entity.MonsterName,
                                LootName = entity.LootName
                            }
                    );
                return query.OrderByDescending(e => e.HistoryId).ToList();
            }
        }
        public EventModel GetMonsterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Monsters
                        .Single(e => e.MonsterId == id && e.OwnerId == _userId);
                return
                    new EventModel
                    {
                        MonsterId = entity.MonsterId,
                        MonsterName = entity.MonsterName
                    };
            }
        }

        public bool AddHistory(EventModel model)
        {
            // Entity is loot they are making
            var entity =
                new History()
                {
                    // Sets the class to take in the model information (What the user inputs)
                    OwnerId = _userId,
                    MonsterId = model.MonsterId,
                    MonsterName = model.MonsterName,
                    LootName = model.LootName

                };
            // Calls the database as 'ctx'
            using (var ctx = new ApplicationDbContext())
            {
                ctx.History.Add(entity); // Adds loot to the database
                return ctx.SaveChanges() == 1; // Saves the entry
            }
        }
    }
}