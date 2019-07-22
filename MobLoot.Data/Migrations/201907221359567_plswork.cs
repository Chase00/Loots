namespace MobLoot.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class plswork : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.History",
                c => new
                    {
                        HistoryId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        MonsterId = c.Int(nullable: false),
                        MonsterName = c.String(),
                        LootName = c.String(),
                    })
                .PrimaryKey(t => t.HistoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.History");
        }
    }
}
