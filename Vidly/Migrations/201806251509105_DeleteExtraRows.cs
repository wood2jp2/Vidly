namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteExtraRows : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Movies WHERE Id BETWEEN 6 and 10");
        }
        
        public override void Down()
        {
        }
    }
}
