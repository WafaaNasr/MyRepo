namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedingGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id,Name) Values(1,'Comedy'),(2,'Action'),(3,'Family'),(4,'Romance')");
        }

        public override void Down()
        {
        }
    }
}
