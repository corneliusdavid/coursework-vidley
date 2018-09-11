namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: true, maxLength: 255));
            Sql("UPDATE MembershipTypes SET NAME = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET NAME = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET NAME = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET NAME = 'Annual' WHERE Id = 4");
        }

        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
