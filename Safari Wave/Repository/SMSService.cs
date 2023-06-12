using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System.Drawing.Printing;
using Twilio.Rest.Verify.V2.Service;

namespace Safari_Wave.Repository
{
    public class SMSService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
       
        private readonly ILogger<SMSService> _logger;
        private readonly string _verifySid;
        

        public SMSService(string accountSid, string authToken,  ILogger<SMSService> logger,string verifySid)
        {
            _accountSid = accountSid;
            _authToken = authToken;
            _logger = logger;
            _verifySid = verifySid;
           

        }
      
        public async Task<string> SendOTPSMS(decimal phoneNumber)
        {
            try
            {
                TwilioClient.Init(_accountSid, _authToken);

                 var message = await VerificationResource.CreateAsync(

                    to:$"+91{phoneNumber}",
                    channel:"sms",
                    pathServiceSid:_verifySid
                );

                return  message.Sid;
            }
            catch (Exception ex)
            {

                // Handle exception/log error
                _logger.LogError("Error in sending sms" + ex.Message);
                
                return null;
            }
        }
        public async Task<bool> CheckVerification(string phonenumber, string otp, string verificationSid)
        {
            try
            {
                var verificationCheck = await VerificationCheckResource.CreateAsync(
                    to: phonenumber,
                    code: otp,
                    pathServiceSid: _verifySid,
                    verificationSid: verificationSid

                );

                return verificationCheck.Status == "approved";
            }
            catch (Exception ex)
            {
                _logger.LogError("Error checking verification: " + ex.Message);
                return false;
            }
        }
    }
}
