namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropEverything : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            //DropForeignKey("dbo.Movies", "Genre_Id1", "dbo.Genres");
            //DropTable("dbo.Genres");
            
            //DropIndex("dbo.Movies", new[] { "Genre_Id1" });
            //DropColumn("dbo.Movies", "Genre_Id");
            
        }
        
        public override void Down()
        {
            /*
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "Genre_Id1", c => c.Int());
            AddColumn("dbo.Movies", "Genre_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "Genre_Id1");
            AddForeignKey("dbo.Movies", "Genre_Id1", "dbo.Genres", "Id");
            */
        }
    }
}
