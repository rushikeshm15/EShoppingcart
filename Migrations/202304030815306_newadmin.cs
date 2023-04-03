namespace eshopping.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class newadmin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.user_details", "Isadmin", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "False")
                    },
                }));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.user_details", "Isadmin", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValue",
                        new AnnotationValues(oldValue: "False", newValue: null)
                    },
                }));
        }
    }
}
