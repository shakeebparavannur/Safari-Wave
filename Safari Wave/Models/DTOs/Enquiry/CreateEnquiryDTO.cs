namespace Safari_Wave.Models.DTOs.Enquiry
{
    public class CreateEnquiryDTO
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public decimal PhoneNo { get; set; }
        public string? Message { get; set; }
    }
}
