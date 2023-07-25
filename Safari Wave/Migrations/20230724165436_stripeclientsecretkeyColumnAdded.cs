using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Safari_Wave.Migrations
{
    /// <inheritdoc />
    public partial class stripeclientsecretkeyColumnAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientSecret",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientSecret",
                table: "Booking");
        }
    }
}
