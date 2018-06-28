namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropRedundantGenreIdAndPopulate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "GenreId");
            Sql("UPDATE Movies SET Genre_Id = 5 WHERE Id = 1");
            Sql("UPDATE Movies SET Genre_Id = 1 WHERE Id = 2");
            Sql("UPDATE Movies SET Genre_Id = 1 WHERE Id = 3");
            Sql("UPDATE Movies SET Genre_Id = 3 WHERE Id = 4");
            Sql("UPDATE Movies SET Genre_Id = 4 WHERE Id = 5");
        }
        
        public override void Down()
        {
        }
    }
}
