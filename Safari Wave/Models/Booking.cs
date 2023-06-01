using System;
using System.Collections.Generic;

namespace Safari_Wave.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int PackageId { get; set; }

    public DateTime Date { get; set; }

    public DateTime DateOfTrip { get; set; }

    public string UserId { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int NoOfPerson { get; set; }

    public decimal Amount { get; set; }

    public string Payment { get; set; } = null!;

    public virtual ICollection<Cancellation> Cancellations { get; set; } = new List<Cancellation>();

    public virtual ICollection<ConfirmedBooking> ConfirmedBookings { get; set; } = new List<ConfirmedBooking>();

    public virtual Package Package { get; set; } = null!;

    public virtual UserDatum User { get; set; } = null!;
}
