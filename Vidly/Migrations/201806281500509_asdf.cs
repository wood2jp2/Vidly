namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.Movies", new[] { "Genre_Id1" });
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Movies", "Genre_Id1", "dbo.Genres");
            //DropIndex("dbo.Movies", new[] { "Genre_Id1" });
        }
    }
}
