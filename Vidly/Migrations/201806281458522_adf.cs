namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adf : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.Movies", new[] { "Genre_Id1" });
        }
        
        public override void Down()
        {

        }
    }
}
