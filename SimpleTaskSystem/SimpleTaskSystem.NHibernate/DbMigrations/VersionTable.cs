using FluentMigrator.VersionTableInfo;

namespace SimpleTaskSystem.DbMigrations
{
    /// <summary>
    /// FluentMigrator reads this class as configuration before starting migration.
    /// </summary>
    [VersionTableMetaData]
    public class VersionTable : DefaultVersionTableMetaData
    {
        /// <summary>
        /// Declares the table name which is used to store migration history.
        /// </summary>
        public override string TableName
        {
            get
            {
                return "StsVersionInfo";
            }
        }
    }
}
