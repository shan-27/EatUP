namespace EatUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetodetailsid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "_DetailsID", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "_GenertatedOrderID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "_GenertatedOrderID", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "_DetailsID");
        }
    }
}
