namespace Safari_Wave.Models.DTOs.Booking
{
    public class BookingResponseDTO
    {
        public int BookingId { get; set; }
        public int PackageId { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public DateTime DateOfTrip { get; set; }
        public string Status { get; set; } = "pending";
        public int NoOfPerson { get; set; }
        public decimal Amount { get; set; }
        public string Payment { get; set; } = "pending";
    }
}
