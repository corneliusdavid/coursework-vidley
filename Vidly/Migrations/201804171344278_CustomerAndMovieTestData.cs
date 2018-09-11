using System.Web.UI;

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerAndMovieTestData : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Movies (Name, Year) VALUES ('The Matrix', 2005)");
            Sql(@"INSERT INTO Movies (Name, Year) VALUES ('Serenity', 2008)");

            Sql(@"INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId) VALUES ('Tom Ford', 'False', 1)");
            Sql(@"INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId) VALUES ('Sally Simple', 'True', 2)");
            Sql(@"INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId) VALUES ('Willy Wonka', 'True', 3)");
        }
        
        public override void Down()
        {
        }
    }
}
