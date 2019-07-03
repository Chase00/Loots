using MobLoot.Data;
using MobLoot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobLoot.Services
{
    public class MonstersService
    {
        private readonly Guid _userId;
        public MonstersService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMonster(MonstersCreate model)
        {
            var entity =
                new Monsters()
                {
                    OwnerId = _userId,
                    MonsterName = model.MonsterName,
                    MonsterDesc = model.MonsterDesc,
                    MonsterLevel = short.Parse(model.MonsterLevel)
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Monsters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MonstersListItem> GetMonsters() // Allows us to see the specific notes that belong to a specific user
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Monsters
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new MonstersListItem
                            {
                                MonsterName = e.MonsterName,
                                MonsterDesc = e.MonsterDesc,
                                MonsterLevel = e.MonsterLevel,
                            }
                    );
                return query.ToArray();
            }
        }
    }
}
