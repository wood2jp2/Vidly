namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropGenreId : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.Movies", new[] { "Genre_Id1" });
            //DropColumn("dbo.Movies", "Genre_Id");
            //RenameColumn(table: "dbo.Movies", name: "Genre_Id1", newName: "Genre_Id");
            //AlterColumn("dbo.Movies", "Genre_Id", c => c.Int());
            //CreateIndex("dbo.Movies", "Genre_Id");
        }
        
        public override void Down()
        {
            //DropIndex("dbo.Movies", new[] { "Genre_Id" });
            //AlterColumn("dbo.Movies", "Genre_Id", c => c.Byte(nullable: false));
            //RenameColumn(table: "dbo.Movies", name: "Genre_Id", newName: "Genre_Id1");
            //AddColumn("dbo.Movies", "Genre_Id", c => c.Byte(nullable: false));
            //CreateIndex("dbo.Movies", "Genre_Id1");
        }
    }
}
