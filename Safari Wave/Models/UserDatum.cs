using System;
using System.Collections.Generic;

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

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual ICollection<Cancellation> Cancellations { get; } = new List<Cancellation>();

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();
}
