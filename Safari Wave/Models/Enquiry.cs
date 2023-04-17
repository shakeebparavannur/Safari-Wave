using System;
using System.Collections.Generic;

namespace Safari_Wave.Models;

public partial class Enquiry
{
    public int EnquiryId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public decimal PhoneNo { get; set; }

    public string? Message { get; set; }

    public DateTime EnquiryDate { get; set; }

    public string? TrackingStatus { get; set; }

    public DateTime? LastTrackingDate { get; set; }
}
