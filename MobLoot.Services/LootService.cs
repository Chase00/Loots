using MobLoot.Data;
using MobLoot.Models.Loot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobLoot.Services
{
    public class LootService
    {
        // Sets the current logged in user to the user that will recieve their information
        private readonly Guid _userId;
        public LootService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateLoot(LootCreate model)
        {
            // Entity is loot they are making
            var entity =
                new Loot()
                {
                    // Sets the class to take in the model information (What the user inputs)
                    OwnerId = _userId,
                    LootName = model.LootName,
                    LootDesc = model.LootDesc,
                    MonsterId = model.MonsterId
                };
            // Calls the database as 'ctx'
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Loot.Add(entity); // Adds loot to the database
                return ctx.SaveChanges() == 1; // Saves the entry
            }
        }
        public IEnumerable<LootListItem> GetLoot()
        {
            // Calls the database
            using (var ctx = new ApplicationDbContext())
            {
                // sets the database to 'query'
                var query = ctx
                    .Loot
                    .Where(entity => entity.OwnerId == _userId) // .Where filters to check to verify the logged in user is the creator
                    .Select(
                        entity => // Commands the entity to go to a new instance of LootListItem
                            new LootListItem
                            {
                                // Sets the class to take in the model information (What the user inputs)
                                LootId = entity.LootId,
                                LootName = entity.LootName,
                                LootDesc = entity.LootDesc,
                                MonsterName = entity.Monsters.MonsterName

                            }
                    );
                // Returns the Information
                return query.OrderBy(prod => prod.MonsterName).ToArray();
            }
        }
        public LootDetails GetLootById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Loot
                        .Single(e => e.LootId == id && e.OwnerId == _userId);
                return
                    new LootDetails
                    {
                        LootId = entity.LootId,
                        LootName = entity.LootName,
                        LootDesc = entity.LootDesc,
                        MonsterId = entity.MonsterId,
                        MonsterName = entity.Monsters.MonsterName
                    };
            }
        }
        public bool UpdateLoot(LootEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Loot
                        .Single(e => e.LootId == model.LootId && e.OwnerId == _userId);

                entity.LootId = model.LootId;
                entity.LootName = model.LootName;
                entity.LootDesc = model.LootDesc;
                entity.MonsterId = model.MonsterId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteLoot(int LootId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Loot
                        .Single(e => e.LootId == LootId && e.OwnerId == _userId);

                ctx.Loot.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
