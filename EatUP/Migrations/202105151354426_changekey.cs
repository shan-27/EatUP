namespace EatUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changekey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Admins");
            AlterColumn("dbo.Admins", "Admin_username", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Admins", "Admin_username");
            DropColumn("dbo.Admins", "AdminID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Admins");
            AlterColumn("dbo.Admins", "Admin_username", c => c.String());
            AddPrimaryKey("dbo.Admins", "AdminID");
        }
    }
}
