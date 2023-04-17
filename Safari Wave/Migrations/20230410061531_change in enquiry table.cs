using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Safari_Wave.Migrations
{
    /// <inheritdoc />
    public partial class changeinenquirytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enquiry",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNo = table.Column<decimal>(name: "Phone No", type: "numeric(18,0)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EnquiryDate = table.Column<DateTime>(name: "Enquiry Date", type: "date", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    PackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Describtion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Facilities = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    NumberofPerson = table.Column<int>(name: "Number of Person", type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AdditionPricePerson = table.Column<int>(name: "Addition Price / Person", type: "int", nullable: true),
                    NoofCustomers = table.Column<int>(name: "No of Customers", type: "int", nullable: true),
                    Cover_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.PackId);
                });

            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    UserName = table.Column<string>(name: "User Name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(name: "Full Name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNo = table.Column<decimal>(name: "Phone No", type: "numeric(18,0)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(user_name())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    Image_Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Gallery_Package",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "PackId");
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(type: "int", nullable: false),
                    Employee_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Employee_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_Img_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Package_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Employee_Id);
                    table.ForeignKey(
                        name: "FK_Employee_Pack",
                        column: x => x.Package_Id,
                        principalTable: "Package",
                        principalColumn: "PackId");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Date_of_Trip = table.Column<DateTime>(type: "date", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    payment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "Booking_Package_FK",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "PackId");
                    table.ForeignKey(
                        name: "Booking_User_FK",
                        column: x => x.UserId,
                        principalTable: "UserData",
                        principalColumn: "User Name");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_User",
                        column: x => x.User_Name,
                        principalTable: "UserData",
                        principalColumn: "User Name");
                    table.ForeignKey(
                        name: "Review_Package_FK",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "PackId");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Sales_Package",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "PackId");
                    table.ForeignKey(
                        name: "FK_Sales_User",
                        column: x => x.UserName,
                        principalTable: "UserData",
                        principalColumn: "User Name");
                });

            migrationBuilder.CreateTable(
                name: "Cancellation",
                columns: table => new
                {
                    CancellationId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancellation", x => x.CancellationId);
                    table.ForeignKey(
                        name: "Cancel_Booking_FK",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "BookingId");
                    table.ForeignKey(
                        name: "Cancellation_User_FK",
                        column: x => x.UserId,
                        principalTable: "UserData",
                        principalColumn: "User Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PackageId",
                table: "Booking",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cancellation_BookingId",
                table: "Cancellation",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Cancellation_UserId",
                table: "Cancellation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_PackageId",
                table: "Gallery",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_PackageId",
                table: "Review",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_User_Name",
                table: "Review",
                column: "User_Name");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_PackageId",
                table: "Sales",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserName",
                table: "Sales",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Package_Id",
                table: "Team",
                column: "Package_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cancellation");

            migrationBuilder.DropTable(
                name: "Enquiry");

            migrationBuilder.DropTable(
                name: "Gallery");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "UserData");
        }
    }
}
