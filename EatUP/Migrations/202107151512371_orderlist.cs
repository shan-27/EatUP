namespace EatUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderlist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Rand_Order_id = c.Int(nullable: false),
                        _Customer_iD = c.Int(nullable: false),
                        Order_Date = c.String(),
                        Order_Time = c.String(),
                        Itemname = c.String(),
                        Item_id = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
