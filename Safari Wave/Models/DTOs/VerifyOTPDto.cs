using Safari_Wave.Models;

public class VerifyOTPDTO
{
    public decimal PhoneNo { get; set; }
    public string Otp { get; set; }
    public UserDatum UserDatum { get; set; }
}
