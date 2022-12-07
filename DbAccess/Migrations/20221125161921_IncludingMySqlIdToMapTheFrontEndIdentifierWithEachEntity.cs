using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IncludingMySqlIdToMapTheFrontEndIdentifierWithEachEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MySqlId",
                table: "UserPollingStationVisit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MySqlId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MySqlId",
                table: "PollingStationPhoto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MySqlId",
                table: "PollingStation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MySqlId",
                table: "UserPollingStationVisit");

            migrationBuilder.DropColumn(
                name: "MySqlId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "MySqlId",
                table: "PollingStationPhoto");

            migrationBuilder.DropColumn(
                name: "MySqlId",
                table: "PollingStation");
        }
    }
}
