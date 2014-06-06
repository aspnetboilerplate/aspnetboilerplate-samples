using FluentMigrator;

namespace SimpleTaskSystem.DbMigrations.V20140410
{
    [Migration(2014041002)]
    public class _02_CreateTasksTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("StsTasks")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey().NotNullable()
                .WithColumn("AssignedPersonId").AsInt32().ForeignKey("StsPeople", "Id").Nullable()
                .WithColumn("Description").AsString(256).NotNullable()
                .WithColumn("State").AsByte().NotNullable().WithDefaultValue(1) //1: TaskState.New
                .WithColumn("CreationTime").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }
    }
}