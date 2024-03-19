using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovedStartAndEndDateFromVenue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndAtDateTime",
                schema: "Venue",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "IsBooked",
                schema: "Venue",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "StartAtDateTime",
                schema: "Venue",
                table: "Venues");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndAtDateTime",
                schema: "Venue",
                table: "Venues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                schema: "Venue",
                table: "Venues",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartAtDateTime",
                schema: "Venue",
                table: "Venues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
