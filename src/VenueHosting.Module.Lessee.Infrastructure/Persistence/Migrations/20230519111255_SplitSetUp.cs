using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenueHosting.Module.Lessee.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SplitSetUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Lessee");

            migrationBuilder.CreateTable(
                name: "LesseeReviews",
                schema: "Lessee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LesseeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    RatingGiven = table.Column<float>(type: "real", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LesseeReviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessees",
                schema: "Lessee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LesseeReviewIds",
                schema: "Lessee",
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
                        principalSchema: "Lessee",
                        principalTable: "Lessees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenueId",
                schema: "Lessee",
                columns: table => new
                {
                    Id1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LesseeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueId", x => x.Id1);
                    table.ForeignKey(
                        name: "FK_VenueId_Lessees_LesseeId",
                        column: x => x.LesseeId,
                        principalSchema: "Lessee",
                        principalTable: "Lessees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LesseeReviewIds_LesseeId",
                schema: "Lessee",
                table: "LesseeReviewIds",
                column: "LesseeId");

            migrationBuilder.CreateIndex(
                name: "IX_VenueId_LesseeId",
                schema: "Lessee",
                table: "VenueId",
                column: "LesseeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LesseeReviewIds",
                schema: "Lessee");

            migrationBuilder.DropTable(
                name: "LesseeReviews",
                schema: "Lessee");

            migrationBuilder.DropTable(
                name: "VenueId",
                schema: "Lessee");

            migrationBuilder.DropTable(
                name: "Lessees",
                schema: "Lessee");
        }
    }
}
