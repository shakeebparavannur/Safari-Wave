using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Safari_Wave.Models;

public partial class SafariWaveContext : DbContext
{
    public SafariWaveContext()
    {
    }

    public SafariWaveContext(DbContextOptions<SafariWaveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Cancellation> Cancellations { get; set; }

    public virtual DbSet<ConfirmedBooking> ConfirmedBookings { get; set; }

    public virtual DbSet<Enquiry> Enquiries { get; set; }

    public virtual DbSet<Gallery> Galleries { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<UserDatum> UserData { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.ToTable("Booking");

            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.DateOfTrip)
                .HasColumnType("date")
                .HasColumnName("Date_of_Trip");
            entity.Property(e => e.NoOfPerson).HasColumnName("No_Of_Person");
            entity.Property(e => e.Payment).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UserId).HasMaxLength(50);

            entity.HasOne(d => d.Package).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Booking_Package_FK");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Booking_User_FK");
        });

        modelBuilder.Entity<Cancellation>(entity =>
        {
            entity.ToTable("Cancellation");

            entity.Property(e => e.CancellationId).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Reason).HasMaxLength(50);
            entity.Property(e => e.UserId).HasMaxLength(50);

            entity.HasOne(d => d.Booking).WithMany(p => p.Cancellations)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cancel_Booking_FK");

            entity.HasOne(d => d.User).WithMany(p => p.Cancellations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cancellation_User_FK");
        });

        modelBuilder.Entity<ConfirmedBooking>(entity =>
        {
            entity.ToTable("Confirmed_Booking");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Booking).WithMany(p => p.ConfirmedBookings)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_ConfirmBook");
        });

        modelBuilder.Entity<Enquiry>(entity =>
        {
            entity.ToTable("Enquiry");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.EnquiryDate)
                .HasColumnType("date")
                .HasColumnName("Enquiry Date");
            entity.Property(e => e.LastTrackingDate).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhoneNo)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Phone No");
        });

        modelBuilder.Entity<Gallery>(entity =>
        {
            entity.HasKey(e => e.ImageId);

            entity.ToTable("Gallery");

            entity.Property(e => e.ImageId).ValueGeneratedNever();
            entity.Property(e => e.ImageUrl).HasColumnName("Image_Url");

            entity.HasOne(d => d.Package).WithMany(p => p.Galleries)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gallery_Package");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.PackId);

            entity.ToTable("Package");

            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.CoverImage).HasColumnName("Cover_Image");
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.MinNoOfPerson).HasColumnName("Min No of Person");
            entity.Property(e => e.NoOfCustomers).HasColumnName("No of Customers");
            entity.Property(e => e.OfferPrice).HasColumnType("money");
            entity.Property(e => e.PricePerHead)
                .HasColumnType("money")
                .HasColumnName("Price per Head");
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Review");

            entity.Property(e => e.Review1).HasColumnName("Review");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("User_Name");

            entity.HasOne(d => d.Package).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Review_Package_FK");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_User");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.Package).WithMany()
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Package");

            entity.HasOne(d => d.UserNameNavigation).WithMany()
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_User");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.ToTable("Team");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("Employee_Id");
            entity.Property(e => e.EmployeeDescription).HasColumnName("Employee_Description");
            entity.Property(e => e.EmployeeImgUrl).HasColumnName("Employee_Img_Url");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .HasColumnName("Employee_Name");
            entity.Property(e => e.PackageId).HasColumnName("Package_Id");

            entity.HasOne(d => d.Package).WithMany(p => p.Teams)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Pack");
        });

        modelBuilder.Entity<UserDatum>(entity =>
        {
            entity.HasKey(e => e.UserName);

            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("User Name");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("Full Name");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.OtpExpirationTime).HasColumnType("datetime");
            entity.Property(e => e.PhoneNo)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Phone No");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValueSql("(user_name())");
            entity.Property(e => e.State).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
