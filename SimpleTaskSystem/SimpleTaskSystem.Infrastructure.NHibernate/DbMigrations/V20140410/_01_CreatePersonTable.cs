using FluentMigrator;

namespace SimpleTaskSystem.DbMigrations.V20140410
{
    [Migration(2014041001)]
    public class _01_CreatePersonTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("StsPeople")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(32).NotNullable();

            Insert.IntoTable("StsPeople")
                .Row(new { Name = "Douglas Adams" })
                .Row(new { Name = "Isaac Asimov" })
                .Row(new { Name = "George Orwell" })
                .Row(new { Name = "Thomas More" });
        }
    }
}
