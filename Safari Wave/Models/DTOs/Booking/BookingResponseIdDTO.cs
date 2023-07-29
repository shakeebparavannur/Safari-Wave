namespace Safari_Wave.Models.DTOs.Booking
{
    public class BookingResponseIdDTO
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
        public string? StripePaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
        public virtual Package Package { get; set; } = null!;
        public virtual UserDatum User { get; set; } = null!;
    }
}
