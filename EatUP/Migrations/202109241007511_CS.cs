namespace EatUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CS_form",
                c => new
                    {
                        CS_formID = c.Int(nullable: false, identity: true),
                        CS_form_Name = c.String(),
                        CS_form_Email = c.String(nullable: false),
                        CS_form_Subject = c.String(maxLength: 50),
                        CS_form_Message = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.CS_formID);
            
            AddColumn("dbo.Customers", "CS_Form_CS_formID", c => c.Int());
            CreateIndex("dbo.Customers", "CS_Form_CS_formID");
            AddForeignKey("dbo.Customers", "CS_Form_CS_formID", "dbo.CS_form", "CS_formID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "CS_Form_CS_formID", "dbo.CS_form");
            DropIndex("dbo.Customers", new[] { "CS_Form_CS_formID" });
            DropColumn("dbo.Customers", "CS_Form_CS_formID");
            DropTable("dbo.CS_form");
        }
    }
}
