namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JoinMembershipTypeAndCustomerTables : DbMigration
    {
        public override void Up()
        {
            Sql("SELECT Customers.Name, MembershipTypes.Name FROM Customers INNER JOIN MembershipTypes ON Customers.MembershipTypeId = MembershipTypes.Id");
        }
        
        public override void Down()
        {
        }
    }
}
