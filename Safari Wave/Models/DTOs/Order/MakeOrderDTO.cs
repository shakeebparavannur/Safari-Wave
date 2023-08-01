namespace Safari_Wave.Models.DTOs.Order
{
    public class MakeOrderDTO
    {
        public int BookingId { get; set; }

        public DateTime DateOfTrip { get; set; }

        public string? Status { get; set; }

        public decimal Amount { get; set; }

        public string? StripePaymentIntentId { get; set; }

        public string? PaymentStatus { get; set; }
    }
}
