namespace Safari_Wave.Models.DTOs.Users
{
    public class CreateUserDTO
    {
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public int PhoneNo { get; set; }

        public string Address { get; set; } = null!;

        public int Pincode { get; set; }

        public string State { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
