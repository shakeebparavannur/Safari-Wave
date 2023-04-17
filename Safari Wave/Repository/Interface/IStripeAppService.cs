using Safari_Wave.Models.Stripe;

namespace Safari_Wave.Repository.Interface
{
    public interface IStripeAppService
    {
        Task<StripeCustomer> AddStripeCustomer(AddStripeCustomer customer, CancellationToken ct);
        Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct);
    }
}
