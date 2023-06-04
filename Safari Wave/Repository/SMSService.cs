using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Safari_Wave.Repository
{
    public class SMSService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _fromNumber;

        public SMSService(string accountSid, string authToken, string fromNumber)
        {
            _accountSid = accountSid;
            _authToken = authToken;
            _fromNumber = fromNumber;
        }
        public string GenerateOTP()
        {
            // Generate a random 6-digit OTP
            var random = new Random();
            return random.Next(10000, 99999).ToString();
        }
        public async Task<bool> SendOTPSMS(decimal phoneNumber, string otp)
        {
            try
            {
                TwilioClient.Init(_accountSid, _authToken);

                 var message = await MessageResource.CreateAsync(
                    body: $"Your OTP is {otp}",
                    from: new PhoneNumber(_fromNumber),
                    to: new PhoneNumber($"+91{phoneNumber}")
                );

                return true;
            }
            catch (Exception ex)
            {
                
                // Handle exception/log error
                //throw Exception(ex.Message);
                return false;
            }
        }
    }
}
