namespace EatUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fooditem1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Food_Item", "Item_Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Food_Item", "Item_Status");
        }
    }
}
