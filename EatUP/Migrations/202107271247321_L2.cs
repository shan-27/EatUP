namespace EatUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class L2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Order_Details_Main_Order_DetailsID", c => c.Int());
            CreateIndex("dbo.Orders", "Order_Details_Main_Order_DetailsID");
            AddForeignKey("dbo.Orders", "Order_Details_Main_Order_DetailsID", "dbo.Main_Order_Details", "Main_Order_DetailsID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Order_Details_Main_Order_DetailsID", "dbo.Main_Order_Details");
            DropIndex("dbo.Orders", new[] { "Order_Details_Main_Order_DetailsID" });
            DropColumn("dbo.Orders", "Order_Details_Main_Order_DetailsID");
        }
    }
}
