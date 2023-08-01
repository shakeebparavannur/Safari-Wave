using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Safari_Wave.Models;

public partial class Order
{
    public int Id { get; set; }

    public int BookingId { get; set; }

    public DateTime DateOfTrip { get; set; }

    public string? Status { get; set; }

    public decimal Amount { get; set; }

    public string? StripePaymentIntentId { get; set; }

    public string? PaymentStatus { get; set; }
    
    public virtual Booking Booking { get; set; } = null!;
}
