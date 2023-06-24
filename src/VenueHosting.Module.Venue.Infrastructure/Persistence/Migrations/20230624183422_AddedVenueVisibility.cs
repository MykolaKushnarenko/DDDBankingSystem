using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedVenueVisibility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VenueReservationIds",
                schema: "Venue");

            migrationBuilder.DropTable(
                name: "VenueReviewIds",
                schema: "Venue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                schema: "Venue",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                schema: "Venue",
                table: "Venues");

            migrationBuilder.RenameTable(
                name: "Reservations",
                schema: "Venue",
                newName: "VenueReservations",
                newSchema: "Venue");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Venue",
                table: "VenueReviews",
                newName: "VenueReviewId");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Venue",
                table: "VenueReservations",
                newName: "ReservationId");

            migrationBuilder.AddColumn<int>(
                name: "Visibility",
                schema: "Venue",
                table: "Venues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VenueReservations",
                schema: "Venue",
                table: "VenueReservations",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_VenueReviews_VenueId",
                schema: "Venue",
                table: "VenueReviews",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_VenueReservations_VenueId",
                schema: "Venue",
                table: "VenueReservations",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_VenueReservations_Venues_VenueId",
                schema: "Venue",
                table: "VenueReservations",
                column: "VenueId",
                principalSchema: "Venue",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VenueReviews_Venues_VenueId",
                schema: "Venue",
                table: "VenueReviews",
                column: "VenueId",
                principalSchema: "Venue",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VenueReservations_Venues_VenueId",
                schema: "Venue",
                table: "VenueReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_VenueReviews_Venues_VenueId",
                schema: "Venue",
                table: "VenueReviews");

            migrationBuilder.DropIndex(
                name: "IX_VenueReviews_VenueId",
                schema: "Venue",
                table: "VenueReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VenueReservations",
                schema: "Venue",
                table: "VenueReservations");

            migrationBuilder.DropIndex(
                name: "IX_VenueReservations_VenueId",
                schema: "Venue",
                table: "VenueReservations");

            migrationBuilder.DropColumn(
                name: "Visibility",
                schema: "Venue",
                table: "Venues");

            migrationBuilder.RenameTable(
                name: "VenueReservations",
                schema: "Venue",
                newName: "Reservations",
                newSchema: "Venue");

            migrationBuilder.RenameColumn(
                name: "VenueReviewId",
                schema: "Venue",
                table: "VenueReviews",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                schema: "Venue",
                table: "Reservations",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                schema: "Venue",
                table: "Venues",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                schema: "Venue",
                table: "Reservations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "VenueReservationIds",
                schema: "Venue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueReservationIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VenueReservationIds_Venues_VenueId",
                        column: x => x.VenueId,
                        principalSchema: "Venue",
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenueReviewIds",
                schema: "Venue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueReviewIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VenueReviewIds_Venues_VenueId",
                        column: x => x.VenueId,
                        principalSchema: "Venue",
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VenueReservationIds_VenueId",
                schema: "Venue",
                table: "VenueReservationIds",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_VenueReviewIds_VenueId",
                schema: "Venue",
                table: "VenueReviewIds",
                column: "VenueId");
        }
    }
}
