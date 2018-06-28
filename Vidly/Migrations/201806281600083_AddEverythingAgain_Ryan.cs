namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEverythingAgain_Ryan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            //AddColumn("dbo.Movies", "Genre_Id", c => c.Byte(nullable: false));
            //AddColumn("dbo.Movies", "Genre_Id1", c => c.Int()); // Creating new Genre_Id column
            //CreateIndex("dbo.Movies", "Genre_Id1"); // Indexing new Genre_Id column
            //AddForeignKey("dbo.Movies", "Genre_Id1", "dbo.Genres", "Id");
            //DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
            //
        }
        
        public override void Down() // Reverse db changes
        {
            //DropForeignKey("dbo.Movies", "Genre_Id1", "dbo.Genres");
            //DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            //DropIndex("dbo.Movies", new[] { "Genre_Id" }); - Already created
            // DropColumn("dbo.Movies", "Genre_Id1"); - Do not want
            // DropColumn("dbo.Movies", "Genre_Id");  - Created / droped in earlier migration
            DropTable("dbo.Genres");
        }
    }
}
