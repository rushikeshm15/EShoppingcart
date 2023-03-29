namespace eshopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phonenumberdatatypeupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.user_details", "Phonenumber", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.user_details", "Phonenumber", c => c.Int(nullable: false));
        }
    }
}
