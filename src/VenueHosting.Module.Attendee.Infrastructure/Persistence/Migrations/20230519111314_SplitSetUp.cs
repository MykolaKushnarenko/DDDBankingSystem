using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenueHosting.Module.Attendee.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SplitSetUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Attendee");

            migrationBuilder.CreateTable(
                name: "AttendeeReviews",
                schema: "Attendee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    RatingGiven = table.Column<float>(type: "real", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendeeReviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attendees",
                schema: "Attendee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendeeBillIds",
                schema: "Attendee",
                columns: table => new
                {
                    Id1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendeeBillIds", x => x.Id1);
                    table.ForeignKey(
                        name: "FK_AttendeeBillIds_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalSchema: "Attendee",
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendeeReservationIds",
                schema: "Attendee",
                columns: table => new
                {
                    Id1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendeeReservationIds", x => x.Id1);
                    table.ForeignKey(
                        name: "FK_AttendeeReservationIds_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalSchema: "Attendee",
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendeeReviewIds",
                schema: "Attendee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendeeReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendeeReviewIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendeeReviewIds_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalSchema: "Attendee",
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendeeVenueIds",
                schema: "Attendee",
                columns: table => new
                {
                    Id1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendeeVenueIds", x => x.Id1);
                    table.ForeignKey(
                        name: "FK_AttendeeVenueIds_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalSchema: "Attendee",
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeBillIds_AttendeeId",
                schema: "Attendee",
                table: "AttendeeBillIds",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeReservationIds_AttendeeId",
                schema: "Attendee",
                table: "AttendeeReservationIds",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeReviewIds_AttendeeId",
                schema: "Attendee",
                table: "AttendeeReviewIds",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeVenueIds_AttendeeId",
                schema: "Attendee",
                table: "AttendeeVenueIds",
                column: "AttendeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendeeBillIds",
                schema: "Attendee");

            migrationBuilder.DropTable(
                name: "AttendeeReservationIds",
                schema: "Attendee");

            migrationBuilder.DropTable(
                name: "AttendeeReviewIds",
                schema: "Attendee");

            migrationBuilder.DropTable(
                name: "AttendeeReviews",
                schema: "Attendee");

            migrationBuilder.DropTable(
                name: "AttendeeVenueIds",
                schema: "Attendee");

            migrationBuilder.DropTable(
                name: "Attendees",
                schema: "Attendee");
        }
    }
}
