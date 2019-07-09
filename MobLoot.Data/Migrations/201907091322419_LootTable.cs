namespace MobLoot.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LootTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Loot", "MonsterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Loot", "MonsterId");
            AddForeignKey("dbo.Loot", "MonsterId", "dbo.Monsters", "MonsterId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loot", "MonsterId", "dbo.Monsters");
            DropIndex("dbo.Loot", new[] { "MonsterId" });
            DropColumn("dbo.Loot", "MonsterId");
        }
    }
}
