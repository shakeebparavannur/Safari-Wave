using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Safari_Wave.Models;

public partial class Package
{
    public int PackId { get; set; }

    public string PackageName { get; set; } = null!;

    public string? Describtion { get; set; }

    public int Duration { get; set; }

    public string Location { get; set; } = null!;

    public string? Facilities { get; set; }

    public decimal PricePerHead { get; set; }

    public int MinNoOfPerson { get; set; }

    public string? Type { get; set; }

    public int? NoOfCustomers { get; set; }

    public string? CoverImage { get; set; }

    public string? Country { get; set; }

    public string? Image1 { get; set; }

    public string? Image2 { get; set; }

    public string? Image3 { get; set; }

    public string? Image4 { get; set; }

    public decimal OfferPrice { get; set; }

    public bool? IsAvailable { get; set; }

    public bool? IsFeatured { get; set; }
    [NotMapped]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    [NotMapped]
    public virtual ICollection<Gallery> Galleries { get; set; } = new List<Gallery>();
    [NotMapped]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    [NotMapped]
    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
