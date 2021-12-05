namespace EatUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolum_for_CSform : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CS_form", "CS_ID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CS_form", "CS_ID");
        }
    }
}
