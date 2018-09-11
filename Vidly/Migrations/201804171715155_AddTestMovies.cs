namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestMovies : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Movies (Name, Year, GenreTypeId, ReleaseDate, DateAdded, NumberInStock) VALUES ('Orbitor 9', 2017, 2, '2017-10-13', '2018-01-20', 5)");
            Sql(@"INSERT INTO Movies (Name, Year, GenreTypeId, ReleaseDate, DateAdded, NumberInStock) VALUES ('Moon', 2009, 3, '2009-06-23', '2017-12-10', 2)");
            Sql(@"INSERT INTO Movies (Name, Year, GenreTypeId, ReleaseDate, DateAdded, NumberInStock) VALUES ('Dispicalbe Me 3', 2017, 5, '2017-08-30', '2017-11-20', 8)");
        }
        
        public override void Down()
        {
        }
    }
}
