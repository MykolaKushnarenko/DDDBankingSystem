using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguredUserWithPlaceAndPartner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partners_Venues_VenueId",
                schema: "Venue",
                table: "Partners");

            migrationBuilder.DropIndex(
                name: "IX_Partners_VenueId",
                schema: "Venue",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                schema: "Venue",
                table: "Partners");

            migrationBuilder.EnsureSchema(
                name: "Replica");

            migrationBuilder.RenameColumn(
                name: "VenueId",
                schema: "Venue",
                table: "Partners",
                newName: "RepresentativeId");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                schema: "Venue",
                table: "Partners",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PartnerReferences",
                schema: "Venue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnerReferences_Venues_VenueId",
                        column: x => x.VenueId,
                        principalSchema: "Venue",
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                schema: "Replica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Replica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartnerReferences_VenueId",
                schema: "Venue",
                table: "PartnerReferences",
                column: "VenueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnerReferences",
                schema: "Venue");

            migrationBuilder.DropTable(
                name: "Places",
                schema: "Replica");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Replica");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                schema: "Venue",
                table: "Partners");

            migrationBuilder.RenameColumn(
                name: "RepresentativeId",
                schema: "Venue",
                table: "Partners",
                newName: "VenueId");

            migrationBuilder.AddColumn<Guid>(
                name: "PartnerId",
                schema: "Venue",
                table: "Partners",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Partners_VenueId",
                schema: "Venue",
                table: "Partners",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_Venues_VenueId",
                schema: "Venue",
                table: "Partners",
                column: "VenueId",
                principalSchema: "Venue",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
