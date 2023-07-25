using Microsoft.EntityFrameworkCore.Migrations;
using Safari_Wave.Models;

#nullable disable

namespace Safari_Wave.Migrations
{
    /// <inheritdoc />
    public partial class newcolumnadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                    name: "StripePaymentIntentId",
                    table: "Booking",
                    nullable: true

                );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
