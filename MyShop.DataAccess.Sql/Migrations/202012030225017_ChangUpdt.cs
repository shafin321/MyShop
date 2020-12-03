namespace MyShop.DataAccess.Sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangUpdt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BasketItems", "BasketId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BasketItems", "BasketId");
            AddForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets");
            DropIndex("dbo.BasketItems", new[] { "BasketId" });
            AlterColumn("dbo.BasketItems", "BasketId", c => c.String());
        }
    }
}
