using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Safari_Wave.Models;

public partial class UserDatum
{
    public string UserName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public decimal PhoneNo { get; set; }

    public string Address { get; set; } = null!;

    public int Pincode { get; set; }

    public string State { get; set; } = null!;

    public string? Password { get; set; }

    public string Role { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? VerificationSid { get; set; }

    public bool IsOtpVerified { get; set; }

    public DateTime? OtpExpirationTime { get; set; }

    public bool IsEmailVerified { get; set; }
    [NotMapped]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    [NotMapped]
    public virtual ICollection<Cancellation> Cancellations { get; set; } = new List<Cancellation>();
    [NotMapped]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
