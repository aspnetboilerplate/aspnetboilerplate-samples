using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpCoreEf7JsonColumnDemo.Migrations
{
    /// <inheritdoc />
    public partial class Ef7JsonColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Metadata",
                table: "AbpTenants",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Metadata",
                table: "AbpTenants");
        }
    }
}
