namespace MVC_EF_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        ProductCategory_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Category", t => t.ProductCategory_CategoryId)
                .Index(t => t.ProductCategory_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ProductCategory_CategoryId", "dbo.Category");
            DropIndex("dbo.Product", new[] { "ProductCategory_CategoryId" });
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
