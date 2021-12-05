namespace EatUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordertableupdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "_GenertatedOrderID", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Rand_Order_id");
            DropColumn("dbo.Orders", "_Customer_iD");
            DropColumn("dbo.Orders", "Order_Date");
            DropColumn("dbo.Orders", "Order_Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Order_Time", c => c.String());
            AddColumn("dbo.Orders", "Order_Date", c => c.String());
            AddColumn("dbo.Orders", "_Customer_iD", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Rand_Order_id", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "_GenertatedOrderID");
        }
    }
}
