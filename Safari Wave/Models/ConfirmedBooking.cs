using System;
using System.Collections.Generic;

namespace Safari_Wave.Models;

public partial class ConfirmedBooking
{
    public int Id { get; set; }

    public int BookingId { get; set; }

    public DateTime Date { get; set; }

    public string? Status { get; set; }

    public decimal Amount { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
