namespace EatUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class newfooditem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Food_Item",
                c => new
                {
                    Food_ItemID = c.Int(nullable: false, identity: true),
                    Item_Name = c.String(),
                    Item_Price = c.Int(nullable: false),
                    Item_Discription = c.String(),
                    Item_Category = c.String(),
                    Iten_ImageURL = c.String(),
                })
                .PrimaryKey(t => t.Food_ItemID);

        }

        public override void Down()
        {
            DropTable("dbo.Food_Item");
        }
    }
}
