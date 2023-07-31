using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Safari_Wave.Migrations
{
    /// <inheritdoc />
    public partial class AddedStripePaymentIntentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                   name: "StripePaymentIntentId",
                   table: "Order",
                   nullable: true

               );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
