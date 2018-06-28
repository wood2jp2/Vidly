namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieModelGenreUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_Id1", "dbo.Genres");
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id1" });
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            //DropColumn("dbo.Movies", "Genre_Id");
            //RenameColumn(table: "dbo.Movies", name: "Genre_Id1", newName: "Genre_Id");
            AlterColumn("dbo.Movies", "Genre_Id", c => c.Int(nullable: false));
            //AlterColumn("dbo.Movies", "Genre_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            AlterColumn("dbo.Movies", "Genre_Id", c => c.Int());
            AlterColumn("dbo.Movies", "Genre_Id", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.Movies", name: "Genre_Id", newName: "Genre_Id1");
            AddColumn("dbo.Movies", "Genre_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "Genre_Id1");
            AddForeignKey("dbo.Movies", "Genre_Id1", "dbo.Genres", "Id");
        }
    }
}
