namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustomerBirthdateType : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Customers ALTER COLUMN Birthdate date");
        }
        
        public override void Down()
        {
        }
    }
}
