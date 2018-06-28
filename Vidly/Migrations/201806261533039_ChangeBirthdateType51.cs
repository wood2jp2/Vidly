namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBirthdateType51 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Birthdate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: false));
        }
    }
}
