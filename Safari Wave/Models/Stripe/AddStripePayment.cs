namespace Safari_Wave.Models.Stripe
{
    
      public record AddStripePayment(
        string CustomerId,
        string ReceiptEmail,
        string Description,
        string Currency,
        long Amount);

}
