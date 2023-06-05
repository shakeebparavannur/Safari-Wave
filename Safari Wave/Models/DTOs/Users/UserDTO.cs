namespace Safari_Wave.Models.DTOs.Users
{
    public class UserDTO
    {
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal PhoneNo { get; set; }
        public string Address { get; set; } = null!;
        public decimal Pincode { get; set; }
        public string State { get; set; } = null!;
        public string Role { get; set; } = null!;
        public bool IsOtpVerified { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
