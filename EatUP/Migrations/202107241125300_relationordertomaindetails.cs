namespace EatUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationordertomaindetails : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Main_Order_Details");
            AlterColumn("dbo.Main_Order_Details", "Main_Order_DetailsID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Main_Order_Details", "Main_Order_DetailsID");
            CreateIndex("dbo.Main_Order_Details", "Main_Order_DetailsID");
            AddForeignKey("dbo.Main_Order_Details", "Main_Order_DetailsID", "dbo.Orders", "OrderID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Main_Order_Details", "Main_Order_DetailsID", "dbo.Orders");
            DropIndex("dbo.Main_Order_Details", new[] { "Main_Order_DetailsID" });
            DropPrimaryKey("dbo.Main_Order_Details");
            AlterColumn("dbo.Main_Order_Details", "Main_Order_DetailsID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Main_Order_Details", "Main_Order_DetailsID");
        }
    }
}
