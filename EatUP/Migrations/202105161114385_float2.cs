namespace EatUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class float2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Food_Item", "Item_Price", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Food_Item", "Item_Price", c => c.Int(nullable: false));
        }
    }
}
