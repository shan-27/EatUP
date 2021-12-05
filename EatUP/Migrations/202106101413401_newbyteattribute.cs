namespace EatUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newbyteattribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Food_Item", "Item_Imagecode", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Food_Item", "Item_Imagecode");
        }
    }
}
