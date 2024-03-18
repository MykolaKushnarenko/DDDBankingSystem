using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MovedEnumToSeparateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Lookup");

            migrationBuilder.CreateTable(
                name: "VenueStatuses",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visibilities",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visibilities", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "VenueStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Organized" },
                    { 1, "Started" },
                    { 2, "Finished" },
                    { 3, "Postponed" },
                    { 4, "Cancelled" }
                });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "Visibilities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Public" },
                    { 2, "Private" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Venues_VenueStatus",
                schema: "Venue",
                table: "Venues",
                column: "VenueStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_Visibility",
                schema: "Venue",
                table: "Venues",
                column: "Visibility");

            migrationBuilder.AddForeignKey(
                name: "FK_Venues_VenueStatuses_VenueStatus",
                schema: "Venue",
                table: "Venues",
                column: "VenueStatus",
                principalSchema: "Lookup",
                principalTable: "VenueStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Venues_Visibilities_Visibility",
                schema: "Venue",
                table: "Venues",
                column: "Visibility",
                principalSchema: "Lookup",
                principalTable: "Visibilities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venues_VenueStatuses_VenueStatus",
                schema: "Venue",
                table: "Venues");

            migrationBuilder.DropForeignKey(
                name: "FK_Venues_Visibilities_Visibility",
                schema: "Venue",
                table: "Venues");

            migrationBuilder.DropTable(
                name: "VenueStatuses",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Visibilities",
                schema: "Lookup");

            migrationBuilder.DropIndex(
                name: "IX_Venues_VenueStatus",
                schema: "Venue",
                table: "Venues");

            migrationBuilder.DropIndex(
                name: "IX_Venues_Visibility",
                schema: "Venue",
                table: "Venues");
        }
    }
}
