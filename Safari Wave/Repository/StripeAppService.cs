using Safari_Wave.Models.Stripe;
using Safari_Wave.Repository.Interface;
using Stripe;

namespace Safari_Wave.Repository
{
    public class StripeAppService : IStripeAppService
    {
        private readonly ChargeService _chargeService;
        private readonly CustomerService _customerService;
        private readonly TokenService _tokenService;

        public StripeAppService(ChargeService chargeService,CustomerService customerService, TokenService tokenService)
        {
            _chargeService = chargeService;
            _customerService = customerService;
            _tokenService = tokenService;

        }
        public async Task<StripeCustomer> AddStripeCustomer(AddStripeCustomer customer, CancellationToken ct)
        {
            TokenCreateOptions tokenCreateOptions = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Name = customer.Name,
                    Number = customer.CreditCard.CardNumber,
                    ExpYear = customer.CreditCard.ExpirationYear,
                    ExpMonth = customer.CreditCard.ExpirationMonth,
                    Cvc = customer.CreditCard.Cvc

                }
            };
            Token stripeToken = await _tokenService.CreateAsync(tokenCreateOptions,null,ct);
            CustomerCreateOptions customeOptions = new CustomerCreateOptions
            {
                Name = customer.Name,
                Email = customer.Email,
                Source = stripeToken.Id
            };
            Customer createdCustomer = await _customerService.CreateAsync(customeOptions, null, ct);
            return new StripeCustomer(createdCustomer.Name, createdCustomer.Email, createdCustomer.Id);
        }

        public async Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct)
        {
            ChargeCreateOptions paymentOptions = new ChargeCreateOptions
            {
                Customer = payment.CustomerId,
                ReceiptEmail = payment.ReceiptEmail,
                Description = payment.Description,
                Currency = payment.Currency,
                Amount = payment.Amount
            };
            var createdpayment = await _chargeService.CreateAsync(paymentOptions, null, ct);

            return new StripePayment(
                  createdpayment.CustomerId,
                  createdpayment.ReceiptEmail,
                  createdpayment.Description,
                  createdpayment.Currency,
                  createdpayment.Amount,
                  createdpayment.Id
                );
        }
    }
}
