﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Safari_Wave.Models;

#nullable disable

namespace Safari_Wave.Migrations
{
    [DbContext(typeof(SafariWaveContext))]
    [Migration("20230724165436_stripeclientsecretkeyColumnAdded")]
    partial class stripeclientsecretkeyColumnAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Safari_Wave.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<string>("ClientSecret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateOfTrip")
                        .HasColumnType("date")
                        .HasColumnName("Date_of_Trip");

                    b.Property<int>("NoOfPerson")
                        .HasColumnType("int")
                        .HasColumnName("No_Of_Person");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<string>("Payment")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StripePaymentIntentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BookingId");

                    b.HasIndex("PackageId");

                    b.HasIndex("UserId");

                    b.ToTable("Booking", (string)null);
                });

            modelBuilder.Entity("Safari_Wave.Models.Cancellation", b =>
                {
                    b.Property<int>("CancellationId")
                        .HasColumnType("int");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Reason")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CancellationId");

                    b.HasIndex("BookingId");

                    b.HasIndex("UserId");

                    b.ToTable("Cancellation", (string)null);
                });

            modelBuilder.Entity("Safari_Wave.Models.ConfirmedBooking", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("Confirmed_Booking", (string)null);
                });

            modelBuilder.Entity("Safari_Wave.Models.Enquiry", b =>
                {
                    b.Property<int>("EnquiryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnquiryId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("EnquiryDate")
                        .HasColumnType("date")
                        .HasColumnName("Enquiry Date");

                    b.Property<DateTime?>("LastTrackingDate")
                        .HasColumnType("date");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PhoneNo")
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("Phone No");

                    b.Property<string>("TrackingStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EnquiryId");

                    b.ToTable("Enquiry", (string)null);
                });

            modelBuilder.Entity("Safari_Wave.Models.Gallery", b =>
                {
                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Image_Url");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasIndex("PackageId");

                    b.ToTable("Gallery", (string)null);
                });

            modelBuilder.Entity("Safari_Wave.Models.Package", b =>
                {
                    b.Property<int>("PackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackId"));

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CoverImage")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cover_Image");

                    b.Property<string>("Describtion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Facilities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MinNoOfPerson")
                        .HasColumnType("int")
                        .HasColumnName("Min No of Person");

                    b.Property<int?>("NoOfCustomers")
                        .HasColumnType("int")
                        .HasColumnName("No of Customers");

                    b.Property<decimal>("OfferPrice")
                        .HasColumnType("money");

                    b.Property<string>("PackageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PricePerHead")
                        .HasColumnType("money")
                        .HasColumnName("Price per Head");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PackId");

                    b.ToTable("Package", (string)null);
                });

            modelBuilder.Entity("Safari_Wave.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Review1")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Review");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("User_Name");

                    b.HasKey("ReviewId");

                    b.HasIndex("PackageId");

                    b.HasIndex("UserName");

                    b.ToTable("Review", (string)null);
                });

            modelBuilder.Entity("Safari_Wave.Models.Sale", b =>
                {
                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasIndex("PackageId");

                    b.HasIndex("UserName");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Safari_Wave.Models.Team", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("Employee_Id");

                    b.Property<string>("EmployeeDescription")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Employee_Description");

                    b.Property<string>("EmployeeImgUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Employee_Img_Url");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Employee_Name");

                    b.Property<int>("PackageId")
                        .HasColumnType("int")
                        .HasColumnName("Package_Id");

                    b.HasKey("EmployeeId");

                    b.HasIndex("PackageId");

                    b.ToTable("Team", (string)null);
                });

            modelBuilder.Entity("Safari_Wave.Models.UserDatum", b =>
                {
                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("User Name");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Full Name");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOtpVerified")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("OtpExpirationTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PhoneNo")
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("Phone No");

                    b.Property<int>("Pincode")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValueSql("(user_name())");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VerificationSid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserName");

                    b.ToTable("UserData");
                });

            modelBuilder.Entity("Safari_Wave.Models.Booking", b =>
                {
                    b.HasOne("Safari_Wave.Models.Package", "Package")
                        .WithMany("Bookings")
                        .HasForeignKey("PackageId")
                        .IsRequired()
                        .HasConstraintName("Booking_Package_FK");

                    b.HasOne("Safari_Wave.Models.UserDatum", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("Booking_User_FK");

                    b.Navigation("Package");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Safari_Wave.Models.Cancellation", b =>
                {
                    b.HasOne("Safari_Wave.Models.Booking", "Booking")
                        .WithMany("Cancellations")
                        .HasForeignKey("BookingId")
                        .IsRequired()
                        .HasConstraintName("Cancel_Booking_FK");

                    b.HasOne("Safari_Wave.Models.UserDatum", "User")
                        .WithMany("Cancellations")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("Cancellation_User_FK");

                    b.Navigation("Booking");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Safari_Wave.Models.ConfirmedBooking", b =>
                {
                    b.HasOne("Safari_Wave.Models.Booking", "Booking")
                        .WithMany("ConfirmedBookings")
                        .HasForeignKey("BookingId")
                        .IsRequired()
                        .HasConstraintName("FK_Booking_ConfirmBook");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Safari_Wave.Models.Gallery", b =>
                {
                    b.HasOne("Safari_Wave.Models.Package", "Package")
                        .WithMany("Galleries")
                        .HasForeignKey("PackageId")
                        .IsRequired()
                        .HasConstraintName("FK_Gallery_Package");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("Safari_Wave.Models.Review", b =>
                {
                    b.HasOne("Safari_Wave.Models.Package", "Package")
                        .WithMany("Reviews")
                        .HasForeignKey("PackageId")
                        .IsRequired()
                        .HasConstraintName("Review_Package_FK");

                    b.HasOne("Safari_Wave.Models.UserDatum", "UserNameNavigation")
                        .WithMany("Reviews")
                        .HasForeignKey("UserName")
                        .IsRequired()
                        .HasConstraintName("FK_Review_User");

                    b.Navigation("Package");

                    b.Navigation("UserNameNavigation");
                });

            modelBuilder.Entity("Safari_Wave.Models.Sale", b =>
                {
                    b.HasOne("Safari_Wave.Models.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId")
                        .IsRequired()
                        .HasConstraintName("FK_Sales_Package");

                    b.HasOne("Safari_Wave.Models.UserDatum", "UserNameNavigation")
                        .WithMany()
                        .HasForeignKey("UserName")
                        .IsRequired()
                        .HasConstraintName("FK_Sales_User");

                    b.Navigation("Package");

                    b.Navigation("UserNameNavigation");
                });

            modelBuilder.Entity("Safari_Wave.Models.Team", b =>
                {
                    b.HasOne("Safari_Wave.Models.Package", "Package")
                        .WithMany("Teams")
                        .HasForeignKey("PackageId")
                        .IsRequired()
                        .HasConstraintName("FK_Employee_Pack");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("Safari_Wave.Models.Booking", b =>
                {
                    b.Navigation("Cancellations");

                    b.Navigation("ConfirmedBookings");
                });

            modelBuilder.Entity("Safari_Wave.Models.Package", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Galleries");

                    b.Navigation("Reviews");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Safari_Wave.Models.UserDatum", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Cancellations");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
