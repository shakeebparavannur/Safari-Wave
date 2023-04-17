using System.ComponentModel.DataAnnotations;

namespace Safari_Wave.Models.DTOs
{
    public class CreatePackageDto
    {
        [Required(ErrorMessage = "Package Name is Required Field")]
        public string PackageName { get; set; } = null!;

        public string? Describtion { get; set; }
        [Required(ErrorMessage = "Duration of the package is a required field")]
        public int Duration { get; set; }
        [Required(ErrorMessage = "You need to specify the location")]
        public string Location { get; set; } = null!;

        public string? Facilities { get; set; }
        [Required(ErrorMessage = "You need to enter a price")]
        public decimal PricePerHead { get; set; }
        [Required(ErrorMessage = "Enter the number of person allowed")]
        public int MinNoOfPerson { get; set; }
        public string? Type { get; set; }
        public string? Country { get; set; }
        public IFormFile? CoverImage { get; set; }
        public IFormFile? Image1 { get; set; }
        public IFormFile? Image2 { get; set; }
        public IFormFile? Image3 { get; set; }
        public IFormFile? Image4 { get; set; }

    }
}
