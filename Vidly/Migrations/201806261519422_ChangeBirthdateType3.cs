namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBirthdateType3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
        }
    }
}
