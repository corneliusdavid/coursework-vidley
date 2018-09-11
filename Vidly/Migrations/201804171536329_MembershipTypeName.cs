namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipTypeName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(maxLength: 255));
            Sql("UPDATE MembershipTypes SET NAME = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET NAME = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET NAME = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET NAME = 'Annual' WHERE Id = 4");
        }

        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
