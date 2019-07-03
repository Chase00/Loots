namespace MobLoot.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedloottable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loot",
                c => new
                    {
                        LootId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        LootName = c.String(nullable: false, maxLength: 30),
                        LootDesc = c.String(nullable: false, maxLength: 400),
                    })
                .PrimaryKey(t => t.LootId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Loot");
        }
    }
}
