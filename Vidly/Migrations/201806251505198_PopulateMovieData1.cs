namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieData1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('Hangover', 'Comedy', '2018/1/1', GETDATE(), 1)");
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('Die Hard', 'Action', '2018/1/1', GETDATE(), 2)");
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('The Terminator', 'Action', '2018/1/1', GETDATE(), 4)");
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('Toy Story', 'Family', '2018/1/1', GETDATE(), 5)");
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('Titanic', 'Romance', '2018/1/1', GETDATE(), 32)");
        }
        
        public override void Down()
        {
        }
    }
}
