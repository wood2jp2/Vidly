namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropGenreIdColumn : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Movies", "Genre_Id1", "dbo.Genres");
            //DropIndex("dbo.Movies", new[] { "Genre_Id1" });
            
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Movies", "Genre_Id", c => c.Byte(nullable: false));
        }
    }
}
