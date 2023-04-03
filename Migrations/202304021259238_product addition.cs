namespace eshopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productaddition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Productname = c.String(),
                        Productdescription = c.String(),
                        Productprice = c.Int(),
                        Categoryid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
