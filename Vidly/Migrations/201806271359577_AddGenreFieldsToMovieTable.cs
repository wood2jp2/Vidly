namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddGenreFieldsToMovieTable : DbMigration
    {
        public override void Up()
        {
            
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropColumn("dbo.Movies", "Genre_Id");
            DropColumn("dbo.Movies", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
