using System;
using System.Collections.Generic;

namespace Safari_Wave.Models;

public partial class Cancellation
{
    public int CancellationId { get; set; }

    public int BookingId { get; set; }

    public DateTime Date { get; set; }

    public string? Reason { get; set; }

    public string UserId { get; set; } = null!;

    public virtual Booking Booking { get; set; } = null!;

    public virtual UserDatum User { get; set; } = null!;
}
