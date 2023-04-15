using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenueHosting.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AlteredTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "AttendeeReviewId");

            migrationBuilder.DropTable(
                name: "Attendees_ReservationIds");

            migrationBuilder.DropTable(
                name: "Attendees_VenueIds");

            migrationBuilder.DropTable(
                name: "BillId");

            migrationBuilder.DropTable(
                name: "LesseeReviewId");

            migrationBuilder.DropTable(
                name: "PlaceId");

            migrationBuilder.DropTable(
                name: "ReservationIds");

            migrationBuilder.CreateTable(
                name: "AttendeeBillIds",
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
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendeeReservationIds",
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
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendeeReviewIds",
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
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendeeVenueIds",
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
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LesseeReviewIds",
                columns: table => new
                {
                    Id1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LesseeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LesseeReviewIds", x => x.Id1);
                    table.ForeignKey(
                        name: "FK_LesseeReviewIds_Lessees_LesseeId",
                        column: x => x.LesseeId,
                        principalTable: "Lessees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerPlaceIds",
                columns: table => new
                {
                    Id1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerPlaceIds", x => x.Id1);
                    table.ForeignKey(
                        name: "FK_OwnerPlaceIds_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenueActivities",
                columns: table => new
                {
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueActivities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_VenueActivities_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenueReservationIds",
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
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeBillIds_AttendeeId",
                table: "AttendeeBillIds",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeReservationIds_AttendeeId",
                table: "AttendeeReservationIds",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeReviewIds_AttendeeId",
                table: "AttendeeReviewIds",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeVenueIds_AttendeeId",
                table: "AttendeeVenueIds",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LesseeReviewIds_LesseeId",
                table: "LesseeReviewIds",
                column: "LesseeId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerPlaceIds_OwnerId",
                table: "OwnerPlaceIds",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_VenueActivities_VenueId",
                table: "VenueActivities",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_VenueReservationIds_VenueId",
                table: "VenueReservationIds",
                column: "VenueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendeeBillIds");

            migrationBuilder.DropTable(
                name: "AttendeeReservationIds");

            migrationBuilder.DropTable(
                name: "AttendeeReviewIds");

            migrationBuilder.DropTable(
                name: "AttendeeVenueIds");

            migrationBuilder.DropTable(
                name: "LesseeReviewIds");

            migrationBuilder.DropTable(
                name: "OwnerPlaceIds");

            migrationBuilder.DropTable(
                name: "VenueActivities");

            migrationBuilder.DropTable(
                name: "VenueReservationIds");

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activities_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendeeReviewId",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendeeReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendeeReviewId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendeeReviewId_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendees_ReservationIds",
                columns: table => new
                {
                    Id1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees_ReservationIds", x => x.Id1);
                    table.ForeignKey(
                        name: "FK_Attendees_ReservationIds_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendees_VenueIds",
                columns: table => new
                {
                    Id1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees_VenueIds", x => x.Id1);
                    table.ForeignKey(
                        name: "FK_Attendees_VenueIds_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillId",
                columns: table => new
                {
                    Id1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillId", x => x.Id1);
                    table.ForeignKey(
                        name: "FK_BillId_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LesseeReviewId",
                columns: table => new
                {
                    Id1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LesseeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LesseeReviewId", x => x.Id1);
                    table.ForeignKey(
                        name: "FK_LesseeReviewId_Lessees_LesseeId",
                        column: x => x.LesseeId,
                        principalTable: "Lessees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaceId",
                columns: table => new
                {
                    Id1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceId", x => x.Id1);
                    table.ForeignKey(
                        name: "FK_PlaceId_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationIds_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_VenueId",
                table: "Activities",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeReviewId_AttendeeId",
                table: "AttendeeReviewId",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_ReservationIds_AttendeeId",
                table: "Attendees_ReservationIds",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_VenueIds_AttendeeId",
                table: "Attendees_VenueIds",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BillId_AttendeeId",
                table: "BillId",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LesseeReviewId_LesseeId",
                table: "LesseeReviewId",
                column: "LesseeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceId_OwnerId",
                table: "PlaceId",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationIds_VenueId",
                table: "ReservationIds",
                column: "VenueId");
        }
    }
}
