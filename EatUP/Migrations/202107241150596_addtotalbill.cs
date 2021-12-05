namespace EatUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtotalbill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Main_Order_Details", "TotalBill", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Main_Order_Details", "TotalBill");
        }
    }
}
