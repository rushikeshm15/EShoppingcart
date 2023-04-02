namespace eshopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.user_details", "Name", c => c.String(nullable: false));
            DropColumn("dbo.user_details", "Firstname");
            DropColumn("dbo.user_details", "Lastname");
            DropColumn("dbo.user_details", "City");
            DropColumn("dbo.user_details", "Address");
            DropColumn("dbo.user_details", "PostalCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.user_details", "PostalCode", c => c.Int(nullable: false));
            AddColumn("dbo.user_details", "Address", c => c.String());
            AddColumn("dbo.user_details", "City", c => c.String());
            AddColumn("dbo.user_details", "Lastname", c => c.String(nullable: false));
            AddColumn("dbo.user_details", "Firstname", c => c.String(nullable: false));
            DropColumn("dbo.user_details", "Name");
        }
    }
}
