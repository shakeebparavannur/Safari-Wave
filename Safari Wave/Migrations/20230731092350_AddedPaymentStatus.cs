using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Safari_Wave.Migrations
{
    /// <inheritdoc />
    public partial class AddedPaymentStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Order",
                newName: "Date_of_Trip");

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Date_of_Trip",
                table: "Order",
                newName: "Date");
        }
    }
}
