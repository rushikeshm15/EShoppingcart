namespace eshopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.user_details", "Isadmin", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.user_details", "Isadmin");
        }
    }
}
