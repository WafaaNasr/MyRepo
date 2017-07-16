namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class FixCustomerAttributesAndNames : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Customers", "BirthDate", "Birthdate");
        }

        public override void Down()
        {
            RenameColumn("dbo.Customers", "Birthdate", "BirthDate");
        }
    }
}
