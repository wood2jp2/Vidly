namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReleaseDates : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET ReleaseDate = '2009/11/6' WHERE Id = 1");
            Sql("UPDATE Movies SET ReleaseDate = '1988/7/15' WHERE Id = 2");
            Sql("UPDATE Movies SET ReleaseDate = '1984/10/26' WHERE Id = 3");
            Sql("UPDATE Movies SET ReleaseDate = '1995/11/22' WHERE Id = 4");
            Sql("UPDATE Movies SET ReleaseDate = '1997/12/9' WHERE Id = 5");
        }
        
        public override void Down()
        {
        }
    }
}
