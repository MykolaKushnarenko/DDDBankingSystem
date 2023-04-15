using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenueHosting.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedPlaceStatusToPlaceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Places");
        }
    }
}
