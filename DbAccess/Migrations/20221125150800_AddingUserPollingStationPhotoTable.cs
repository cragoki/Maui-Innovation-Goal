using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingUserPollingStationPhotoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPollingStationVisit_PollingStations_PollingStationId",
                table: "UserPollingStationVisit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PollingStations",
                table: "PollingStations");

            migrationBuilder.RenameTable(
                name: "PollingStations",
                newName: "PollingStation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PollingStation",
                table: "PollingStation",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PollingStationPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PollingStationId = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollingStationPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollingStationPhoto_PollingStation_PollingStationId",
                        column: x => x.PollingStationId,
                        principalTable: "PollingStation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationPhoto_PollingStationId",
                table: "PollingStationPhoto",
                column: "PollingStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPollingStationVisit_PollingStation_PollingStationId",
                table: "UserPollingStationVisit",
                column: "PollingStationId",
                principalTable: "PollingStation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPollingStationVisit_PollingStation_PollingStationId",
                table: "UserPollingStationVisit");

            migrationBuilder.DropTable(
                name: "PollingStationPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PollingStation",
                table: "PollingStation");

            migrationBuilder.RenameTable(
                name: "PollingStation",
                newName: "PollingStations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PollingStations",
                table: "PollingStations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPollingStationVisit_PollingStations_PollingStationId",
                table: "UserPollingStationVisit",
                column: "PollingStationId",
                principalTable: "PollingStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
