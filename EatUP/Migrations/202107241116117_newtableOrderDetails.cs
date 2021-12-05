namespace EatUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtableOrderDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Main_Order_Details",
                c => new
                    {
                        Main_Order_DetailsID = c.Int(nullable: false, identity: true),
                        Rand_Order_id = c.Int(nullable: false),
                        _Customer_iD = c.Int(nullable: false),
                        Order_Date = c.String(),
                        Order_Time = c.String(),
                    })
                .PrimaryKey(t => t.Main_Order_DetailsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Main_Order_Details");
        }
    }
}
