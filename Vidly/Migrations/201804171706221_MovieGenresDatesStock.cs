namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieGenresDatesStock : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Movies");

            CreateTable(
                "dbo.GenreTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenreTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreTypeId");
            AddForeignKey("dbo.Movies", "GenreTypeId", "dbo.GenreTypes", "Id", cascadeDelete: true);

            Sql(@"INSERT INTO GenreTypes (Name) VALUES ('Comedy')");
            Sql(@"INSERT INTO GenreTypes (Name) VALUES ('Drama')");
            Sql(@"INSERT INTO GenreTypes (Name) VALUES ('Action')");
            Sql(@"INSERT INTO GenreTypes (Name) VALUES ('Romance')");
            Sql(@"INSERT INTO GenreTypes (Name) VALUES ('Family')");
            Sql(@"INSERT INTO GenreTypes (Name) VALUES ('Documentary')");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreTypeId", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreTypeId" });
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "GenreTypeId");
            DropTable("dbo.GenreTypes");
        }
    }
}
