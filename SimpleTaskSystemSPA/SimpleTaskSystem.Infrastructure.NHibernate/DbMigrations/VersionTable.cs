using FluentMigrator.VersionTableInfo;

namespace SimpleTaskSystem.DbMigrations
{
    [VersionTableMetaData]
    public class VersionTable : DefaultVersionTableMetaData
    {
        public override string TableName
        {
            get
            {
                return "StsVersionInfo";
            }
        }
    }
}
